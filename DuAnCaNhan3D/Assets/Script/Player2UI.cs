using TMPro;
using UnityEngine;

public class Player2UI : MonoBehaviour
{
    public TMP_Text playerNameText;
    public TMP_Text playerScoreText;
    public TMP_Text playerLevelText;

    void Start()
    {
        LoadUI();


    }

    public void LoadUI()
    {
        if (GameManager.instance != null && GameManager.instance.currentUser != null)
        {
            UserData user = GameManager.instance.currentUser;
            playerNameText.text = "User: " + user.username;
            playerScoreText.text = user.score.ToString() ;
            playerLevelText.text = "Level: " + user.level;
        }
        else
        {
            playerNameText.text = "No User";
            playerScoreText.text = "Score: 0";
            playerLevelText.text = "Level: 1";
        }
    }
}
