using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject btn;       // Nút Resume / Menu
    public bool isPaused = false;
    public TMP_Text leaderboardText;

    void Start()
    {
        btn.SetActive(false);
        Time.timeScale = 1; // đảm bảo lúc start game không bị dừng
    }

    public void PauseButton()
    {
        if (!isPaused)
        {
            // bật pause
            btn.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
        else
        {
            // tắt pause (resume game)
            btn.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
    }
    public void BackToMenu()
    {
        Debug.Log("Back to menu");
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
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
