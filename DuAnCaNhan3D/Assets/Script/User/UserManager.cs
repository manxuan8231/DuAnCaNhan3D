using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class UserManager : MonoBehaviour
{
    public static UserManager Instance;

    // Danh sách tất cả user
    public List<UserData> users = new List<UserData>();

    // Index user đang active trong danh sách
    public int currentUserIndex = -1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadUsersFromDisk();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void LoadUsersFromDisk()
    {
        users = SaveSystem.LoadAllUsers();
    }

    void SaveUsersToDisk()
    {
        SaveSystem.SaveAllUsers(users);
    }

    // Tạo user mới, chọn luôn
    public void CreateUser(string username)
    {
        if (string.IsNullOrWhiteSpace(username)) return;
        // tránh trùng tên 
        if (users.Any(u => u.username == username))
        {
            Debug.LogWarning("Tên đã tồn tại");          
            return;
        }

        UserData newUser = new UserData(username);
        users.Add(newUser);
        currentUserIndex = users.Count - 1;
        SaveUsersToDisk();
    }

    // Chọn user theo index
    public void SelectUser(int index)
    {
        if (index < 0 || index >= users.Count) return;
        currentUserIndex = index;
        // không cần save khi chỉ chuyển user
    }

    // Lấy user hiện tại (null nếu chưa chọn)
    public UserData GetCurrentUser()
    {
        if (currentUserIndex < 0 || currentUserIndex >= users.Count) return null;
        return users[currentUserIndex];
    }

    // Cập nhật điểm (ghi lại highscore nếu tăng)
    public void AddScoreToCurrentUser(int amount)
    {
        UserData u = GetCurrentUser();
        if (u == null) return;
        u.highscore += amount;
        SaveUsersToDisk();
    }

    // Nếu record mới (ví dụ muốn highscore = max(highscore, newScore))
    public void SetHighscoreIfGreater(int newScore)
    {
        UserData u = GetCurrentUser();
        if (u == null) return;
        if (newScore > u.highscore)
        {
            u.highscore = newScore;
            SaveUsersToDisk();
        }
    }

    // Cập nhật levelPassed nếu levelIndex lớn hơn
    public void SetLevelPassedIfGreater(int levelIndex)
    {
        UserData u = GetCurrentUser();
        if (u == null) return;
        if (levelIndex > u.level)
        {
            u.level = levelIndex;
            SaveUsersToDisk();
        }
    }

    // Lấy sorted leaderboard (bản copy)
    public List<UserData> GetLeaderboard()
    {
        return users.OrderByDescending(x => x.highscore).ToList();
    }
}
