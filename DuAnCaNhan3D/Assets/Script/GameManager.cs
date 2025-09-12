using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // mở danh sách playlist
    public GameObject playlistUI;
    public GameObject newUserUI;
    public GameObject levelUI;
    public GameObject howToplayUI;
    public GameObject leaderBoardUI;



    //  New User
    public TMP_InputField usernameInput;
    public GameObject userItemPrefab;
    public Transform contentParrent;

    

    // UI trên màn hình chính
    public TMP_Text welcomeTxt;
    public TMP_Text levelTxt;
    public TMP_Text scoreTxt;

    public UserData currentUser;


    //gameobject
    public GameObject quitPanel;

    //leaderboard
    public Transform leaderBoardContent;
    public GameObject leaderBoardItemPrefab;

    //Setting
    public GameObject settingUI;
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // giữ lại khi đổi scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Ẩn tất cả UI khi bắt đầu
        quitPanel.SetActive(false);
        howToplayUI.SetActive(false);
        newUserUI.SetActive(false);
        playlistUI.SetActive(false);
        levelUI.SetActive(false);
        leaderBoardUI.SetActive(false);
        settingUI.SetActive(false);
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
                usernameInput.text = "";
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
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game!");
    }
    public void OpenQuitPanel()
    {
        quitPanel.SetActive(true);
    }
    public void CloseQuitPanel()
    {
        quitPanel.SetActive(false);
    }
    public void OpenHowToPlay()
    {
        howToplayUI.SetActive(true);
    }
    public void CloseHowToPlay()
    {
        howToplayUI.SetActive(false);
    }

    public void OpenLeaderBoard()
    {
        leaderBoardUI.SetActive(true);
        //load user
        // Clear item cũ
        foreach (Transform child in leaderBoardContent)
        {
            Destroy(child.gameObject);
        }

        // Load users và sort theo score giảm dần
        List<UserData> users = SaveSystem.GetAllUsers();
        users.Sort((a, b) => b.score.CompareTo(a.score));

        int rank = 1;
        foreach (UserData user in users)
        {
            GameObject slotObj = Instantiate(leaderBoardItemPrefab, leaderBoardContent);
            LeaderBoardSlot slot = slotObj.GetComponent<LeaderBoardSlot>();
            slot.Setup(rank, user.username, user.score);
            rank++;
        }


    }
    public void CloseLeaderBoard()
    {
        leaderBoardUI.SetActive(false);
    }
    public void OpenSetting()
    {
        settingUI.SetActive(true);
    }

    public void CloseSetting()
    {
        settingUI.SetActive(false);
    }
    //start game
    public void StartGame(string sceneName)
    {
        if (currentUser != null)
        {
            currentUser.lastScence = sceneName;
            SaveSystem.Save(currentUser);
            Debug.Log("Lưu cảnh hiện tại: " + sceneName);
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Chưa chọn user!");
        }
    }
}
