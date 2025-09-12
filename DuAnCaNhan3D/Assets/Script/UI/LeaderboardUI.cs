using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LeaderboardUI : MonoBehaviour
{
   
    public Transform contentParent;            // Content trong ScrollView
    public GameObject leaderboardItemPrefab;   // Prefab 1 dòng

    private void Start()
    {
        ShowLeaderboard();
    }

    public void ShowLeaderboard()
    {
        Debug.Log("da show");
        List<UserData> users = SaveSystem.GetAllUsers();

        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        var top = users.OrderByDescending(u => u.score).ToList();

        // Lấy user đang chọn
        string currentUser = GameManager.Instance.currentUser != null ? GameManager.Instance.currentUser.username : "";

        for (int i = 0; i < top.Count; i++)
        {
            GameObject itemObj = Instantiate(leaderboardItemPrefab, contentParent);
            LeaderboardItem item = itemObj.GetComponent<LeaderboardItem>();

            item.SetData(i + 1, top[i].username, top[i].score, currentUser);
        }
    }

}
