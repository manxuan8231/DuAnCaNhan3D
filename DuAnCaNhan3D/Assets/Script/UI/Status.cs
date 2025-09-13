using TMPro;
using UnityEngine;

public class Status : MonoBehaviour
{
  


   
      public TextMeshProUGUI usernameText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;

    private void Start()
    {
        UpdateUI();
    }

    // Hàm gọi để cập nhật UI khi dữ liệu thay đổi
    public void UpdateUI()
    {
        if (GameManager.Instance != null && GameManager.Instance.currentUser != null)
        {
            UserData user = GameManager.Instance.currentUser;
            usernameText.text = "Name: " + user.username;
            scoreText.text = "" + user.score;
            levelText.text = "Level: " + user.level;
        }
    }
}





