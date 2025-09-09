using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_Text leaderboardText;
    public GameObject bxhObj;
    public TMP_Dropdown userDropdown;
    public TMP_Text notifyText;

    private List<UserData> allUsers = new List<UserData>();

    private void Start()
    {
        bxhObj.SetActive(false);
        notifyText.text = "";
        allUsers = SaveSystem.GetAllUsers();
    }

    // ================== BẤM "TẠO" ==================
    public void CreateUser()
    {
        if (!string.IsNullOrWhiteSpace(usernameInput.text))
        {
            string inputName = usernameInput.text.Trim();

            UserData data = SaveSystem.Load(inputName);

            if (data == null)
            {
                // Tạo user mới
                data = new UserData(inputName);
                SaveSystem.Save(data);
                Debug.Log("Tạo user mới: " + inputName);

                allUsers.Add(data);
                ShowNotify("Tạo user thành công!");
            }
            else
            {
                Debug.Log("User đã tồn tại: " + inputName);
                ShowNotify("User đã tồn tại!");
            }

            UpdateDropdown();
        }
        else
        {
            Debug.LogWarning("Tên user không hợp lệ!");
            ShowNotify("Tên user không hợp lệ!");
        }
    }

    // ================== BẤM "CHƠI" ==================
    public void OnStartButton()
    {
        if (userDropdown.value > 0) // 0 = Option mặc định
        {
            string selectedUser = userDropdown.options[userDropdown.value].text;
            PlayerUI.currentUser = selectedUser;

            UserData data = SaveSystem.Load(selectedUser);

            if (data != null)
            {
                Debug.Log("Bắt đầu game với user: " + selectedUser);
                SceneManager.LoadScene(data.lastScence);
            }
        }
        else
        {
            ShowNotify("Chưa chọn user nào!");
            Debug.LogWarning("Chưa chọn user nào!");
        }
    }

    // ================== LEADERBOARD ==================
    public void ShowLeaderboard()
    {
        bxhObj.SetActive(true);
        var top5 = allUsers.OrderByDescending(u => u.score).Take(5).ToList();

        leaderboardText.text = "             Top 5 Highscores \n";
        for (int i = 0; i < top5.Count; i++)
        {
            leaderboardText.text += $"{i + 1}.{top5[i].username} - Score: {top5[i].score} - Level: {top5[i].level}\n";
        }
    }

    public void HideLeaderboard()
    {
        bxhObj.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // ================== CẬP NHẬT DROPDOWN ==================
    private void UpdateDropdown()
    {
        userDropdown.ClearOptions();
        List<string> names = new List<string> { "-- Chọn user --" };
        names.AddRange(allUsers.Select(u => u.username));
        userDropdown.AddOptions(names);
        userDropdown.value = 0; // reset về mặc định
        userDropdown.RefreshShownValue();
    }

    // ================== HIỆN THÔNG BÁO ==================
    private void ShowNotify(string message)
    {
        notifyText.text = message;
        StopAllCoroutines(); // tránh overlap nếu spam
        StartCoroutine(HideNotifyAfterSeconds(3f));
    }

    private IEnumerator HideNotifyAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        notifyText.text = "";
    }
}
