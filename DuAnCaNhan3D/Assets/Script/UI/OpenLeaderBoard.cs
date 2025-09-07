using UnityEngine;

public class OpenLeaderBoard : MonoBehaviour
{
    public GameObject leaderBoard;

    public void OpenLeaderboard()
    {
        leaderBoard.SetActive(true);
    }
    public void CloseLeaderboard()
    {
        leaderBoard.SetActive(false);
    }
}
