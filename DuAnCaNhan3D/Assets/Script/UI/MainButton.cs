using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
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
}
