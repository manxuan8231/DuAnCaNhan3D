using TMPro;
using UnityEngine;

public class LeaderboardItem : MonoBehaviour
{
    public TextMeshProUGUI rankText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI scoreText;
  
    // Gọi khi tạo
    public void SetData(int rank, string username, int score, string currentUser)
    {
        rankText.text = $"#{rank}";
        nameText.text = username;
        scoreText.text = $"{score}";
       

        // Reset màu trắng mặc định
        rankText.color = Color.white;
        nameText.color = Color.white;
        scoreText.color = Color.white;
      

        // Nếu là top 1 → rank màu đỏ
        if (rank == 1)
        {
            rankText.color = Color.red;
        }

        // Nếu là user đang chọn → đổi tên sang đỏ
        if (username == currentUser)
        {
            nameText.color = Color.red;
        }
    }
}
