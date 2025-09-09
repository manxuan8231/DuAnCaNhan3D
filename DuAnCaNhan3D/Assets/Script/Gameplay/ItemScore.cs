using UnityEngine;

public class ItemScore : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bear"))
        {
            Debug.Log("Bear collected score item!");
            AddScore(10); // Thêm 10 điểm
            Destroy(gameObject); // Hủy item sau khi lấy
        }
    }
    // Ví dụ trong một script gameplay
    void AddScore(int amount)
    {
        GameManager.Instance.currentUser.score += amount;
        GameManager.Instance.SaveProgress(); // Lưu lại

        // Tìm HUD và cập nhật UI
        FindAnyObjectByType<Status>().UpdateUI();
    }

}
