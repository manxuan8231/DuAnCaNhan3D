[System.Serializable]
public class UserData
{
    public string username;
    public int score;
    public int level;

    public UserData(string username)
    {
        this.username = username;
        this.score = 0;
        this.level = 1;
    }
}
