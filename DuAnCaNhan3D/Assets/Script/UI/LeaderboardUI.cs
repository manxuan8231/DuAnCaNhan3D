using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LeaderboardUI : MonoBehaviour
{
    public GameObject leaderBoard;
    public TextMeshProUGUI leaderboardText; // Text trên UI để hiển thị

    private void Start ()
    {
        ShowLeaderboard();
    }

    public void ShowLeaderboard()
    {
        Debug.Log("da show");
        List<UserData> users = SaveSystem.GetAllUsers();

        // Sắp xếp theo highScore giảm dần
        var top5 = users.OrderByDescending(u => u.score).Take(5).ToList();

        for (int i = 0; i < top5.Count; i++)
        {         
            leaderboardText.text += $"Top: {i + 1} - Name: {top5[i].username} - Score: {top5[i].score} - Level: {top5[i].level}\n";
        }
    }
   
}
