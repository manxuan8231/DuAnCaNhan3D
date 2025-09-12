using TMPro;
using UnityEngine;

public class UserSlot : MonoBehaviour
{
    public TMP_Text usernameText;
    public void SetName(string name)
    {
        usernameText.text = name;
    }
    public void ChooseUser()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gm != null)
        {
            gm.SelectedUser(usernameText.text);
        }
        else
        {
            Debug.LogWarning("Không tìm thấy GameManager trong cảnh!");

        }
    }
    //delete user
    public void DeleteUser()
    {
        SaveSystem.DeleteUser(usernameText.text);
        Destroy(gameObject);
    }
}

