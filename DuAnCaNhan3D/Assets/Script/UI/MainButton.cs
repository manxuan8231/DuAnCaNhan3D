using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    public GameObject panelUser;
    public GameObject panelNewUser;
    public void OnStartButton()//bắt đầu chơi game
    {
        if (GameManager.Instance.currentUser != null)
        {
            // Lưu user hiện tại trước khi vào game
            GameManager.Instance.SaveProgress();

            // Load scene theo tiến trình đã lưu
            SceneManager.LoadScene(GameManager.Instance.currentUser.lastScene);
        }
        else
        {
            Debug.LogWarning("Chưa chọn user nào!");
        }
    }
    //mở bảng xếp hạng
    public void OpenLeaderboard()
    {
        LeaderboardUI leaderboardUI = FindAnyObjectByType<LeaderboardUI>();
        if (leaderboardUI != null)
        {
            leaderboardUI.leaderBoard.SetActive(true);
            leaderboardUI. leaderboardText.text = "";
           
           
        }

    }
    public void CloseLeaderboard()
    {
        LeaderboardUI leaderboardUI = FindAnyObjectByType<LeaderboardUI>();
        if (leaderboardUI != null)
        {
            leaderboardUI.leaderBoard.SetActive(false);
        }


    }

    //thoát game
    public void OnExitButton()
    {
        Application.Quit();
    }

    //mở đóng danh sách user 
    public void OpenPanelUser()
    {
        panelUser.SetActive(true);
    }
    public void ClosePanelUser()
    {
        panelUser.SetActive(false);
    }

    //mở đóng bảng tạo user
    public void OpenPanelNewUser()
    {
        panelNewUser.SetActive(true);
    }
    public void ClosePanelNewUser() { 
        panelNewUser.SetActive(false);
    }
}
