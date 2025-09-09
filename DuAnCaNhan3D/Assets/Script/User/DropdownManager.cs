using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class DropdownManager : MonoBehaviour
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
        foreach (var user in allUsers)
        {
            options.Add(user.username);
        }

        if (options.Count == 0)
        {
            options.Add("Chưa có user");
        }

        userDropdown.AddOptions(options);
        userDropdown.onValueChanged.AddListener(OnUserSelected);

        // Nếu có user thì chọn user đầu tiên
        if (allUsers.Count > 0)
        {
            SetCurrentUser(0);
        }
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
        GameManager.Instance.currentUser = allUsers[index];
        Debug.Log("Đã chọn user: " + GameManager.Instance.currentUser.username);
    }


   

}
