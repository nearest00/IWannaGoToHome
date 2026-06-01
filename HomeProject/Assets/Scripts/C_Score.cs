using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class C_Score : MonoBehaviour
{
    public float player1Hp = 100f;
    public float player2Hp = 100f;

    public GameObject ResultPanel;
    public TextMeshProUGUI ResultText;
    public TextMeshProUGUI LeftText;
    public TextMeshProUGUI RightText;

    public void TakeDamage(bool isPlayer1, float damage)
    {
        if (isPlayer1)
        {
            player1Hp -= damage;
            player1Hp = Mathf.Max(player1Hp, 0f);
            if (player1Hp == 0)
            {
                ResultPanel.SetActive(true);
                LeftText.text = "Lose";
                RightText.text = "Win";
                ResultText.text = "WINNER : Player 2";
            }
        }
        else
        {
            player2Hp -= damage;
            player2Hp = Mathf.Max(player2Hp, 0f);
            if (player2Hp == 0)
            {
                ResultPanel.SetActive(true);
                LeftText.text = "Win";
                RightText.text = "Lose";
                ResultText.text = "WINNER : Player 1";
            }
        }
    }
}
