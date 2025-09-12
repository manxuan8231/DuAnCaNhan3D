using TMPro;
using UnityEngine;

public class LoadUI : MonoBehaviour
{
    public TMP_Text userNameTxt;
    public TMP_Text scoreTxt;
    public TMP_Text rankTxt;
    public UserData currentUser;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
    }
    public void LoadData(UserData data)
    {
        currentUser = data;
        userNameTxt.text = "Username: " + currentUser.username;
        scoreTxt.text = "Score: " + currentUser.score.ToString();
        rankTxt.text = "Level: " + currentUser.level.ToString();
    }
}
