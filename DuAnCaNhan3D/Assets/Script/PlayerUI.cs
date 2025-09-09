using TMPro;
using UnityEngine;
public class PlayerUI : MonoBehaviour
{
    public TMP_Text usernameInput;
    public TMP_Text scoreInput;
    public TMP_Text levelInput;
    public int score = 0;
    public static string currentUser; // user hiện tại
    void Start()
    {
        if (!string.IsNullOrEmpty(currentUser))
        {
            UserData data = SaveSystem.Load(currentUser);
            if (data != null)
            {
                usernameInput.text = "User: " + data.username;
                score = data.score;
                scoreInput.text = "Score: " + score.ToString();
                levelInput.text = "Level: " + data.level.ToString();
            }
        }
    }
}
