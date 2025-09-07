using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public TMP_InputField usernameInput;

    public void LoginUser()
    {
        if (!string.IsNullOrWhiteSpace(usernameInput.text))
        {
            string inputName = usernameInput.text;

            UserData data = SaveSystem.Load(inputName);

            if (data == null)
            {
                // Tạo user mới
                data = new UserData(inputName);
                SaveSystem.Save(data);
                Debug.Log("Tạo user mới: " + inputName);
            }
            else
            {
                Debug.Log("Đăng nhập user cũ: " + inputName);
            }

    
            // Ghi nhớ user đang login
            PlayerCtrl.currentUser = inputName;

            SceneManager.LoadScene("Map1");
        }
        else
        {
            Debug.Log("Vui lòng nhập tên người dùng hợp lệ.");
        }
    }
}
