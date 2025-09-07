using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportGate : MonoBehaviour
{
    public string targetScene = "Map2"; // tên scene muốn tele đến
    public int id;
    private void OnTriggerEnter(Collider other)
    {
        // Kiểm tra player có tag "Player"
        if (other.CompareTag("Bear"))
        {

            if (GameManager.Instance != null && GameManager.Instance.currentUser != null)
            {
                GameManager.Instance.currentUser.level++;
                GameManager.Instance.currentUser.lastScene = targetScene; // Cập nhật scene 
                  // Lưu lại dữ liệu user trước khi đổi map                                                        
                GameManager.Instance.SaveProgress();
            }
            if (id == 1)
            {
                // Load scene mới
                SceneManager.LoadScene(targetScene);
            }
            else if (id == 2)
            {
                //Win game
                Time.timeScale = 0f;
            }
        }
    }
}
