using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class OpenLeaderBoard : MonoBehaviour
{
    public GameObject leaderBoard;
    public TextMeshProUGUI leaderboardText; // Text trên UI để hiển thị

    private void Start()
    {
        ShowLeaderboard();
    }

    public void ShowLeaderboard()
    {
        List<UserData> users = SaveSystem.GetAllUsers();

        // Sắp xếp theo highScore giảm dần
        var top5 = users.OrderByDescending(u => u.score).Take(5).ToList();

        leaderboardText.text = "      Top 5 Highscores \n\n";

        for (int i = 0; i < top5.Count; i++)
        {
            leaderboardText.text += $"{i + 1}. {top5[i].username} - {top5[i].score}\n";
        }
    }
    public void OpenLeaderboard()
    {
        leaderBoard.SetActive(true);
    }
    public void CloseLeaderboard()
    {
        leaderBoard.SetActive(false);
    }
}
