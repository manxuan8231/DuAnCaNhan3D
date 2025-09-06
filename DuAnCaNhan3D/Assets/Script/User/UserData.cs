using System;

[Serializable]
public class UserData
{
    public string username;
    public int highscore;    
    public int level; 

    public UserData(string name)
    {
        username = name;
        highscore = 0;
        level = 0;
    }
}
