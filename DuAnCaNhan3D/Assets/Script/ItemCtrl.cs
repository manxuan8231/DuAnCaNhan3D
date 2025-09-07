using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    PlayerUI PlayerCtrl;
    void Start()
    {
        PlayerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerCtrl.score += 5;
            PlayerCtrl.scoreInput.text = "Score: " + PlayerCtrl.score.ToString();

            // load dữ liệu user hiện tại từ JSON
            UserData data = SaveSystem.Load(PlayerUI.currentUser);
            if (data != null)
            {
                data.score = PlayerCtrl.score; // cập nhật điểm mới
                SaveSystem.Save(data);         // lưu lại vào file JSON
            }

            // xoá item
            Debug.Log("Đã thu thập ! Điểm số tăng: " + PlayerCtrl.score);
            Destroy(gameObject);
        

        }
    }
}
