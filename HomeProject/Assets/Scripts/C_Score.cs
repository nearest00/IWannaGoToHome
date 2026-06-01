using UnityEngine;

public class C_Score : MonoBehaviour
{
    public float player1Hp = 100f;
    public float player2Hp = 100f;

    public void TakeDamage(bool isPlayer1, float damage)
    {
        if (isPlayer1)
        {
            player1Hp -= damage;
            player1Hp = Mathf.Max(player1Hp, 0f);
        }
        else
        {
            player2Hp -= damage;
            player2Hp = Mathf.Max(player2Hp, 0f);
        }
    }
}
