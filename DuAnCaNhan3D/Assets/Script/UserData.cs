[System.Serializable]
public class UserData
{
    public string username;
    public int score;
    public int level;
    public string lastScence;

    public UserData(string username)
    {
        this.username = username;
        score = 0;
        level = 1;
        lastScence = "Map1";
    }
}
