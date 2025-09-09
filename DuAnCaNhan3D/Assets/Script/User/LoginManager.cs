using UnityEngine;
using TMPro; 

public class LoginManager : MonoBehaviour
{
    public TMP_InputField usernameInput; // Ô nhập username
    public TextMeshProUGUI messageText;  // Text hiển thị thông báo

    private void Start()
    {
        messageText.text = "";
    }

    public void OnLoginButton()//dang ky tai khoản
    {
        string username = usernameInput.text.Trim();

        if (string.IsNullOrEmpty(username))
        {
            messageText.text = "Vui lòng nhập tên!";
            return;
        }

        UserData user;

        // Kiểm tra user đã có chưa
        if (SaveSystem.UserExists(username))
        {
            user = SaveSystem.Load(username);
            messageText.text = "Chào mừng trở lại, " + user.username + "!";
        }
        else
        {
            // Tạo user mới
            user = new UserData(username);
            SaveSystem.Save(user);
            messageText.text = "Tạo tài khoản mới thành công!";
        }

        // Lưu user hiện tại vào GameManager (singleton)
        GameManager.Instance.currentUser = user;

        // Vào scene chơi game 
       // SceneManager.LoadScene(user.lastScene);
    }
   
}
