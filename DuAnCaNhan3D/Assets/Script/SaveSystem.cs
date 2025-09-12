using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static string path = Application.persistentDataPath + "/users.json";

    [System.Serializable]
    private class UserDatabase
    {
        public List<UserData> users = new List<UserData>();
    }

    // Lưu toàn bộ database
    private static void SaveDatabase(UserDatabase db)
    {
        string json = JsonUtility.ToJson(db, true);
        File.WriteAllText(path, json);
    }

    // Load toàn bộ database
    private static UserDatabase LoadDatabase()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<UserDatabase>(json);
        }
        return new UserDatabase();
    }

    // Lưu / update dữ liệu 1 user
    public static void Save(UserData data)
    {
        UserDatabase db = LoadDatabase();

        // Tìm xem user đã tồn tại chưa
        int index = db.users.FindIndex(u => u.username == data.username);
        if (index >= 0)
        {
            db.users[index] = data; // update
        }
        else
        {
            db.users.Add(data); // thêm mới
        }

        SaveDatabase(db);
        Debug.Log(path);
    }

    // Load dữ liệu theo username
    public static UserData Load(string username)
    {
        UserDatabase db = LoadDatabase();
        return db.users.Find(u => u.username == username);
    }

    // Kiểm tra user có tồn tại không
    public static bool UserExists(string username)
    {
        UserDatabase db = LoadDatabase();
        return db.users.Exists(u => u.username == username);
    }

    // (optional) Lấy danh sách toàn bộ user
    public static List<UserData> GetAllUsers()
    {
        UserDatabase db = LoadDatabase();
        return db.users;
    }
    public static UserData GetLastUser()
    {
        UserDatabase db = LoadDatabase();
        if (db.users.Count > 0)
        {
            return db.users[db.users.Count - 1]; // user mới nhất nằm cuối
        }
        return null;
    }
    //DELTE USER
    public static void DeleteUser(string username)
    {
        UserDatabase db = LoadDatabase();
        int index = db.users.FindIndex(u => u.username == username);
        if (index >= 0)
        {
            db.users.RemoveAt(index);
            SaveDatabase(db);
            Debug.Log($"User {username} đã bị xóa.");
        }
        else
        {
            Debug.LogWarning($"Không tìm thấy user {username} để xóa.");
        }
    }

}
