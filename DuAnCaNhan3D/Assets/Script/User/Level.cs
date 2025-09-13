using UnityEngine;
using UnityEngine.UI;

public class LevelImageUI : MonoBehaviour
{
    public Image image1; // Gán trong Inspector
    public Image image2;
    public Image image3;

    public Color activeColor = Color.white; // Màu khi được chọn
    public Color inactiveColor = Color.black; // Màu khi chưa chọn

    private void Start()
    {
        UpdateLevelUI();
    }

    public void UpdateLevelUI()
    {
        if (GameManager.Instance.currentUser == null) return;

        int level = GameManager.Instance.currentUser.level;

        // Reset tất cả về inactive
        image1.color = inactiveColor;
        image2.color = inactiveColor;
        image3.color = inactiveColor;

        // Mở sáng dần theo level
        if (level >= 1) image1.color = activeColor;
        if (level >= 2) image2.color = activeColor;
        if (level >= 3) image3.color = activeColor;
    }
}
