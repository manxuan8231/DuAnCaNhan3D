using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardSlot : MonoBehaviour
{
    public TMP_Text rankingText;
    public TMP_Text nameText;
    public TMP_Text scoreText;
    public Image iconImage;
    public Sprite imageSprite;

    public void Setup(int rank, string playerName, int score)
    {
        rankingText.text = "#" + rank;
        nameText.text = playerName;
        scoreText.text = score.ToString();
        iconImage.sprite = imageSprite;

        // Đổi màu text theo rank
        switch (rank)
        {
            case 1:
                rankingText.color = new Color32(255, 100, 100, 255); // đỏ cam
                nameText.color = new Color32(255, 215, 0, 255); // vàng gold
                break;
            case 2:
                rankingText.color = new Color32(100, 149, 237, 255); // xanh dương
                nameText.color = new Color32(173, 216, 230, 255); // xanh nhạt
                break;
            case 3:
                rankingText.color = new Color32(255, 165, 0, 255); // cam
                nameText.color = new Color32(255, 200, 100, 255);
                break;
            default:
                rankingText.color = Color.white;
                nameText.color = Color.white;
                break;
        }
    }
}
