using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class C_Score : MonoBehaviour
{
    public float player1Hp = 100f;
    public float player2Hp = 100f;

    public Slider player1Slider;
    public Slider player2Slider;

    float targetPlayer1Hp;
    float targetPlayer2Hp;

    void Start()
    {
        targetPlayer1Hp = player1Hp;
        targetPlayer2Hp = player2Hp;

        player1Slider.maxValue = player1Hp;
        player1Slider.value = player1Hp;

        player2Slider.maxValue = player2Hp;
        player2Slider.value = player2Hp;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(true, 200f);
        }
        player1Slider.value = Mathf.MoveTowards(
            player1Slider.value,
            targetPlayer1Hp,
            50f * Time.deltaTime
        );

        player2Slider.value = Mathf.MoveTowards(
            player2Slider.value,
            targetPlayer2Hp,
            50f * Time.deltaTime
        );
    }

    public void TakeDamage(bool isPlayer1, float damage)
    {
        if (isPlayer1)
        {
            player1Hp -= damage;
            player1Hp = Mathf.Max(player1Hp, 0f);

            targetPlayer1Hp = player1Hp;
        }
        else
        {
            player2Hp -= damage;
            player2Hp = Mathf.Max(player2Hp, 0f);

            targetPlayer2Hp = player2Hp;
        }
    }
}
