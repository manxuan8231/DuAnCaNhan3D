using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // mở danh sách playlist
    public GameObject playlistUI;
    public GameObject newUserUI;
    public GameObject levelUI;


    //  New User
    public TMP_InputField usernameInput;
    public GameObject userItemPrefab;
    public Transform contentParrent;


    // UI trên màn hình chính
    public TMP_Text welcomeTxt;
    public TMP_Text levelTxt;
    public TMP_Text scoreTxt;

    public UserData currentUser;
    void Start()
    {

        newUserUI.SetActive(false);
        playlistUI.SetActive(false);
        levelUI.SetActive(false);
        // Load user mới nhất khi vào game
        currentUser = SaveSystem.GetLastUser();
        if (currentUser != null)
        {
            LoadUserToUI(currentUser);
        }

    }
    // Chọn user từ playlist
    public void SelectedUser(string username)
    {
        UserData data = SaveSystem.Load(username);
        if (data != null)
        {
            currentUser = data;
            LoadUserToUI(currentUser);
            playlistUI.SetActive(false);
            Debug.Log("Đã chọn user: " + username);
        }
        else
        {
            Debug.LogWarning("User không tồn tại: " + username);
        }
    }
    // Load user lên UI chính
    private void LoadUserToUI(UserData user)
    {
        welcomeTxt.text =  user.username;
        levelTxt.text =  user.level.ToString();
        scoreTxt.text = user.score.ToString();
    }
    //QUIT GAME
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game!");
    }

    // Playlist UI
    public void OpenPlaylist()
    {
        // Clear item cũ trong UI
        foreach (Transform child in contentParrent)
        {
            Destroy(child.gameObject);
        }

        // Lấy toàn bộ user từ SaveSystem
        List<UserData> users = SaveSystem.GetAllUsers();

        foreach (UserData user in users)
        {
            GameObject userItem = Instantiate(userItemPrefab, contentParrent);
            userItem.GetComponent<UserSlot>().SetName(user.username);
        }

        playlistUI.SetActive(true);

    }
    // Đóng playlist UI
    public void ClosePlaylist()
    {
        playlistUI.SetActive(false);
    }
    // New User UI
    public void OpenNewUser()
    {
        playlistUI.SetActive(false);
        newUserUI.SetActive(true);
    }
    // Đóng new user UI
    public void CloseNewUser()
    {
        newUserUI.SetActive(false);
    }


    // Tạo user mới
    public void CreateUser()
    {
        if (!string.IsNullOrWhiteSpace(usernameInput.text))
        {
            string inputName = usernameInput.text.Trim();
            UserData data = SaveSystem.Load(inputName);
            if (data == null)
            {
                // Tạo user mới
                data = new UserData(inputName);
                SaveSystem.Save(data);
                Debug.Log("Tạo user mới: " + inputName);
                // Load lên UI luôn
                currentUser = data;
                LoadUserToUI(currentUser);
                Debug.Log($"đã load user lên +   {currentUser}");
                // Tạo item trong danh sách user
                GameObject newUserItem = Instantiate(userItemPrefab, contentParrent);
                newUserItem.GetComponent<UserSlot>().SetName(inputName);
                Debug.Log(newUserItem);
                CloseNewUser();
            }
            else
            {
                Debug.Log("User đã tồn tại: " + inputName);
            }
        }
        else
        {
            Debug.LogWarning("Tên user không hợp lệ!");
        }
    }

    //level UI  
    public void OpenLevelUI()
    {
        levelUI.SetActive(true);
    }
    public void CloseLevelUI()
    {
        levelUI.SetActive(false);
    }

}
