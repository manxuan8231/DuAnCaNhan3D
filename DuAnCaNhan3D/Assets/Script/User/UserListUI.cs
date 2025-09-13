using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserListUI : MonoBehaviour
{
    public GameObject userItemPrefab; // Prefab chứa Text + 2 Button (Select, Delete)
    public Transform contentParent;   // Panel/Content trong ScrollView để chứa user list
    public TextMeshProUGUI textCurrent; // Text để hiển thị user đang chọn
    public TextMeshProUGUI textLevel;
    public TextMeshProUGUI textCoin;
    private List<UserData> allUsers = new List<UserData>();

    private void Start()
    {
        // Load user list
        LoadUsers();

        // Load lại user đã chọn từ PlayerPrefs
        string savedUser = PlayerPrefs.GetString("SelectedUser", "");
        if (!string.IsNullOrEmpty(savedUser))
        {
            // Kiểm tra xem user này có còn trong data không
            foreach (var user in allUsers)
            {
                if (user.username == savedUser)
                {
                    GameManager.Instance.currentUser = user;
                    break;
                }
            }
        }
      

            UpdateCurrentUserText(); // Cập nhật khi mới vào
    }


    public void LoadUsers()
    {
        // Xóa hết item cũ
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        // Lấy toàn bộ user
        allUsers = SaveSystem.GetAllUsers();

        foreach (var user in allUsers)
        {
            GameObject newItem = Instantiate(userItemPrefab, contentParent);

            // Tìm Text và Button trong prefab
            TextMeshProUGUI nameText = newItem.transform.Find("UserName").GetComponent<TextMeshProUGUI>();
            Button selectBtn = newItem.transform.Find("SelectButton").GetComponent<Button>();
            Button deleteBtn = newItem.transform.Find("DeleteButton").GetComponent<Button>();

            // Set tên user
            nameText.text = user.username;

            // Nếu user này đang được chọn -> ẩn nút Select
            if (GameManager.Instance.currentUser != null &&
                GameManager.Instance.currentUser.username == user.username)
            {
                selectBtn.gameObject.SetActive(false);
            }
            else
            {
                selectBtn.gameObject.SetActive(true);
            }

            // Thêm sự kiện cho button Select
            selectBtn.onClick.AddListener(() =>
            {
                GameManager.Instance.currentUser = user;
                PlayerPrefs.SetString("SelectedUser", user.username); // Lưu user đã chọn
                PlayerPrefs.Save();

                Debug.Log("Đã chọn user: " + user.username);
                UpdateCurrentUserText();
                LoadUsers(); // Reload lại để cập nhật nút
            });


            // Thêm sự kiện cho button Delete
            deleteBtn.onClick.AddListener(() =>
            {
                SaveSystem.DeleteUser(user.username);
                Debug.Log("Đã xóa user: " + user.username);

                // Nếu xóa luôn user đang chọn thì clear luôn
                if (GameManager.Instance.currentUser != null &&
                    GameManager.Instance.currentUser.username == user.username)
                {
                    GameManager.Instance.currentUser = null;
                    UpdateCurrentUserText();
                }

                LoadUsers(); // Reload lại danh sách
            });
        }

    }

    public void UpdateCurrentUserText()
    {
        if (GameManager.Instance.currentUser != null)
        {
            textCurrent.text = "" + GameManager.Instance.currentUser.username;
            textLevel.text = ""+GameManager.Instance.currentUser.level;
            textCoin.text = ""+GameManager.Instance.currentUser.score;
        }
        else
        {
            textCurrent.text = "No User";
        }
    }
}
