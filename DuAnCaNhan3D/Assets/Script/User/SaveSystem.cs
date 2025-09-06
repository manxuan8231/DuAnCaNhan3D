using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class UserListWrapper
{
    public List<UserData> users = new List<UserData>();
}

public static class SaveSystem
{
    private static string fileName = "users.json";

    private static string FilePath
    {
        get { return Path.Combine(Application.persistentDataPath, fileName); }
    }

    // Load all users (returns empty list nếu file chưa có)
    public static List<UserData> LoadAllUsers()
    {
        try
        {
            if (!File.Exists(FilePath)) return new List<UserData>();

            string json = File.ReadAllText(FilePath);
            UserListWrapper wrapper = JsonUtility.FromJson<UserListWrapper>(json);
            if (wrapper == null || wrapper.users == null) return new List<UserData>();
            return wrapper.users;
        }
        catch (Exception e)
        {
            Debug.LogError("Tải user error: " + e.Message);
            return new List<UserData>();
        }
    }

    // lưu tất cả danh sách
    public static void SaveAllUsers(List<UserData> users)
    {
        try
        {
            UserListWrapper wrapper = new UserListWrapper();
            wrapper.users = users;
            string json = JsonUtility.ToJson(wrapper, true);
            File.WriteAllText(FilePath, json);
        }
        catch (Exception e)
        {
            Debug.LogError("Save Lỗi: " + e.Message);
        }
    }
}
