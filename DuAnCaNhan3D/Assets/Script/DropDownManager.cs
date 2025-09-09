using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DropDownManager: MonoBehaviour
{
    public TMP_Dropdown userDropdown; // Dropdown UI để chọn user
    private List<UserData> allUsers = new List<UserData>();

    private void Start()
    {
        LoadUsersToDropdown();
    }

    // Load tất cả user từ SaveSystem và đổ vào dropdown
    public void LoadUsersToDropdown()
    {
        userDropdown.ClearOptions();
        allUsers = SaveSystem.GetAllUsers();

        List<string> options = new List<string>();
        options.Add("-- Chọn user --"); // option mặc định

        foreach (var user in allUsers)
        {
            options.Add(user.username);
        }

        if (allUsers.Count == 0)
        {
            options.Clear();
            options.Add("Chưa có user");
        }

        userDropdown.AddOptions(options);
        userDropdown.value = 0; // reset về mặc định
        userDropdown.RefreshShownValue();

        userDropdown.onValueChanged.AddListener(OnUserSelected);
    }

    // Khi chọn user trong dropdown
    private void OnUserSelected(int index)
    {
        if (allUsers.Count > 0 && index < allUsers.Count)
        {
            SetCurrentUser(index);
        }
    }

    // Gán user hiện tại cho GameManager
    private void SetCurrentUser(int index)
    {
        PlayerUI.currentUser = allUsers[index].username;
        Debug.Log("Chọn user: " + PlayerUI.currentUser);
    }
}