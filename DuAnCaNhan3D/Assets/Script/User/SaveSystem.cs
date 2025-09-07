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
            UserDatabase db = JsonUtility.FromJson<UserDatabase>(json);

            // Xóa các phần tử null trong list (nếu có)
            db.users.RemoveAll(u => u == null);

            return db;
        }
        return new UserDatabase();
    }


    // Lưu / update dữ liệu 1 user
    public static void Save(UserData data)
    {
        UserDatabase db = LoadDatabase();

        // Tìm xem user đã tồn tại chưa
        int index = db.users.FindIndex(u => u.userName == data.userName);
        if (index >= 0)
        {
            db.users[index] = data; // update
        }
        else
        {
            db.users.Add(data); // thêm mới
        }

        SaveDatabase(db);
    }

    // Load dữ liệu theo username
    public static UserData Load(string username)
    {
        UserDatabase db = LoadDatabase();
        return db.users.Find(u => u.userName == username);
    }

    // Kiểm tra user có tồn tại không
    public static bool UserExists(string username)
    {
        UserDatabase db = LoadDatabase();
        return db.users.Exists(u => u != null && u.userName == username);
    }


    // (optional) Lấy danh sách toàn bộ user
    public static List<UserData> GetAllUsers()
    {
        UserDatabase db = LoadDatabase();
        return db.users;
    }
   
}