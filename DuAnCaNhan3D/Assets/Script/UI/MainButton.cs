using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    public GameObject leaderBoard;           
    public GameObject panelUser;
    public GameObject panelNewUser;
    public GameObject panelQuitGame; 
    public GameObject panelSetting;
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
       
          leaderBoard.SetActive(true);
          
        

    }
    public void CloseLeaderboard()
    {
       leaderBoard.SetActive(false);
        


    }
    //mo panel quit
    public void OpenPanelQuit()
    {
        panelQuitGame.SetActive(true);
    }
    public void ClosePanelQuit()
    {
        panelQuitGame.SetActive(false);
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

    //setting
    public void OpenPanelSetting() {
        panelSetting.SetActive(true);
    }
    public void ClosePanelSetting() { 
        panelSetting.SetActive(false);
    }
}
