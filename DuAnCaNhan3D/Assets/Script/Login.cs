using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_Text leaderboardText;

    public void LoginUser()
    {
        if (!string.IsNullOrWhiteSpace(usernameInput.text))
        {
            string inputName = usernameInput.text;

            UserData data = SaveSystem.Load(inputName);

            if (data == null)
            {
                // Tạo user mới
                data = new UserData(inputName);
                SaveSystem.Save(data);
                Debug.Log("Tạo user mới: " + inputName);
            }
            else
            {
                Debug.Log("Đăng nhập user cũ: " + inputName);
            }
            

    
            // Ghi nhớ user đang login
            PlayerUI.currentUser = inputName;

            SceneManager.LoadScene(data.lastScence);
        }
        else
        {
            Debug.Log("Vui lòng nhập tên người dùng hợp lệ.");
        }
    }
    public void ShowLeaderboard()
    {
        List<UserData> users = SaveSystem.GetAllUsers();

        // Sắp xếp theo highScore giảm dần
        var top5 = users.OrderByDescending(u => u.score).Take(10).ToList();

        leaderboardText.text = "      Top 10 Highscores \n\n";

        for (int i = 0; i < top5.Count; i++)
        {
            leaderboardText.text += $"{i + 1}. {top5[i].username} - {top5[i].score}\n";
        }
    }
}
