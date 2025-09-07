using UnityEngine;

public class UserData : MonoBehaviour
{ 
    public string userName;
    public int level;
    public int hightScore;

    public UserData(string userName)
    {
        this.userName = userName;
        level = 1;
        hightScore = 0;
    } 
}
