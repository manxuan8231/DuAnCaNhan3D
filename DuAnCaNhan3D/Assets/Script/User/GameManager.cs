using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UserData currentUser;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Giữ qua scene khác
        }
        else
        {
            Destroy(gameObject);
            
        }
    }

    // Hàm này có thể gọi để lưu tiến trình
    public void SaveProgress()
    {
        if (currentUser != null)
        {
            SaveSystem.Save(currentUser);
        }
    }
}
