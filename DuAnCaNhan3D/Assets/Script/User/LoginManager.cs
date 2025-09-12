using UnityEngine;
using TMPro; 

public class LoginManager : MonoBehaviour
{
    public TMP_InputField usernameInput; // Ô nhập username
   

    private void Start()
    {
       
    }

    public void OnLoginButton()//dang ky tai khoản
    {
        string username = usernameInput.text.Trim();

        if (string.IsNullOrEmpty(username))
        {
            return;
        }

        UserData user;

        // Kiểm tra user đã có chưa
        if (SaveSystem.UserExists(username))
        {
            user = SaveSystem.Load(username);
        }
        else
        {
            // Tạo user mới
            user = new UserData(username);
            SaveSystem.Save(user);
        }

        // Lưu user hiện tại vào GameManager (singleton)
        GameManager.Instance.currentUser = user;

        // Vào scene chơi game 
       // SceneManager.LoadScene(user.lastScene);
    }
   
}
