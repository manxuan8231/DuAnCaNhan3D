using TMPro;
using UnityEngine;

public class Status : MonoBehaviour
{
    public TextMeshProUGUI userName;
    public TextMeshProUGUI level;
    public TextMeshProUGUI hightScore;

    private UserData currentUser;
    
    
    void Start()
    {
        if (string.IsNullOrEmpty(GameSession.currentUserName))
        {
            Debug.LogError("Chưa có user đang đăng nhập!");
            return;
        }

        currentUser = SaveSystem.Load(GameSession.currentUserName);

        if (currentUser != null)
        {
            userName.text = $"Name: {currentUser.userName}";
            level.text = $"Level: {currentUser.level}";
            hightScore.text = $"HighScore: {currentUser.hightScore}";
        }
        else
        {
            Debug.LogError("Không tìm thấy user hiện tại: " + GameSession.currentUserName);
        }
    }


}
