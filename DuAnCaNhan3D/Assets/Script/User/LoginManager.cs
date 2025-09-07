using UnityEngine;
using UnityEngine.UI;  // cho InputField, Button
using UnityEngine.SceneManagement;
using TMPro;

public class LoginManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_InputField nameInput;   // drag InputField vào
    public Button startButton;     // drag Button vào

    public void OnStartClicked()
    {
        string enteredName = nameInput.text.Trim().ToString();


        if (string.IsNullOrEmpty(enteredName))
        {
            Debug.LogWarning("Tên không được để trống!");
            return;
        }

        // kiểm tra user có tồn tại không
        if (SaveSystem.UserExists(enteredName))
        {
            Debug.Log("Đã có user: " + enteredName);
            UserData existing = SaveSystem.Load(enteredName);
            Debug.Log($"Load thành công: Level {existing.level}, Score {existing.hightScore}");
        }
        else
        {
            Debug.Log("Tạo user mới: " + enteredName);
            UserData newUser = new UserData(enteredName);
            SaveSystem.Save(newUser);
        }

        // chuyển sang scene game
        GameSession.currentUserName = enteredName;
        SceneManager.LoadScene("Map1");
    }
  

}
