using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserListUI : MonoBehaviour
{
    public GameObject userItemPrefab; // Prefab chứa Text + 2 Button (Select, Delete)
    public Transform contentParent;   // Panel/Content trong ScrollView để chứa user list
    public TextMeshProUGUI textCurrent; // Text để hiển thị user đang chọn

    private List<UserData> allUsers = new List<UserData>();

    private void Start()
    {
        LoadUsers();
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

        // Tạo UI item cho từng user
        foreach (var user in allUsers)
        {
            GameObject newItem = Instantiate(userItemPrefab, contentParent);

            // Tìm Text và Button trong prefab
            TextMeshProUGUI nameText = newItem.transform.Find("UserName").GetComponent<TextMeshProUGUI>();
            Button selectBtn = newItem.transform.Find("SelectButton").GetComponent<Button>();
            Button deleteBtn = newItem.transform.Find("DeleteButton").GetComponent<Button>();

            // Set tên user
            nameText.text = user.username;

            // Thêm sự kiện cho button Select
            selectBtn.onClick.AddListener(() =>
            {
                GameManager.Instance.currentUser = user;
                Debug.Log("Đã chọn user: " + user.username);
                UpdateCurrentUserText(); // Cập nhật text hiển thị
            });

            // Thêm sự kiện cho button Delete
            deleteBtn.onClick.AddListener(() =>
            {
                SaveSystem.DeleteUser(user.username);
                Debug.Log("Đã xóa user: " + user.username);
                LoadUsers(); // Reload lại danh sách
            });
        }
    }

    private void UpdateCurrentUserText()
    {
        if (GameManager.Instance.currentUser != null)
        {
            textCurrent.text = "" + GameManager.Instance.currentUser.username;
        }
        else
        {
            textCurrent.text = "Chưa chọn user";
        }
    }
}
