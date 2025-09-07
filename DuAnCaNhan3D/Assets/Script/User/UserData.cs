[System.Serializable]
public class UserData
{
    public string username;
    public int score;
    public int level;
    public string lastScene; // lưu map cuối cùng của user

    public UserData(string username)
    {
        this.username = username;
        score = 0;
        level = 0;
        lastScene = "Map1"; 
    }
}