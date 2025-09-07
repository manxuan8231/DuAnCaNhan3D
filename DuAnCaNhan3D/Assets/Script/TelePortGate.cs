using UnityEngine;
using UnityEngine.SceneManagement;

public class TelePortGate : MonoBehaviour
{
    public string scenceName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            UserData data = SaveSystem.Load(PlayerUI.currentUser);
            if(data != null)
            {
                data.level++;
                data.lastScence = scenceName;
                SaveSystem.Save(data);
            }
            SceneManager.LoadScene(scenceName);

        }
    }
}
