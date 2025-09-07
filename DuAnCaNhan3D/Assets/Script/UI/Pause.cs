using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
   public void OpenPause()
    {
        Time.timeScale = 0f; // Tạm dừng game
        pausePanel.SetActive(true); // Hiện menu tạm dừng
    }
    public void ClosePause()
    {
        Time.timeScale = 1f; // Tiếp tục game
        pausePanel.SetActive(false); // Ẩn menu tạm dừng
    }
    public void ExitToMenu()
    {
        Time.timeScale = 1f; // Đảm bảo game không bị tạm dừng khi về menu
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
