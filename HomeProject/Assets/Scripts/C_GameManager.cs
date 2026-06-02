using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class C_GameManager : MonoBehaviour
{
    public float player1Hp = 100f;
    public float player2Hp = 100f; //인스펙터 설정값

    public Slider player1Slider;
    public Slider player2Slider;

    float targetPlayer1Hp;
    float targetPlayer2Hp; //코드에서 직접 사용하는 값

    bool GameOver = false;
    public CanvasGroup ResultPanel;
    public TextMeshProUGUI ResultText;
    public TextMeshProUGUI LeftText;
    public TextMeshProUGUI RightText;
    public GameObject HPPanel;
    
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
        //테스트용 코드
        if (Input.GetKeyDown(KeyCode.K))
        {
            Damage(true, 20f);
        }
        //데미지와 슬라이더값(시각) 실시간 연동(천천히 움직임)
        player1Slider.value = Mathf.MoveTowards(player1Slider.value, targetPlayer1Hp, 50f * Time.deltaTime);

        player2Slider.value = Mathf.MoveTowards(player2Slider.value, targetPlayer2Hp, 50f * Time.deltaTime);
    }


    public void Damage(bool isPlayer1, float damage)
    //실제 계산에 사용되는 데미지 값 계산
    {
        if (GameOver) return;
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
        StartCoroutine(CheckGameOver());
    }

    IEnumerator CheckGameOver() //슬라이더 때문에 1초 대기
    {
        yield return new WaitForSeconds(1f);

        if (player1Hp <= 0f)
        {
            HPPanel.SetActive(false);
            LeftText.text = "Lose";
            RightText.text = "Win";
            ResultText.text = "WINNER : Player 2";
            StartCoroutine(FadeIn(ResultPanel));
        }
        else if (player2Hp <= 0f)
        {
            HPPanel.SetActive(false);
            LeftText.text = "Win";
            RightText.text = "Lose";
            ResultText.text = "WINNER : Player 1";
            StartCoroutine(FadeIn(ResultPanel));
        }
    }

    IEnumerator FadeIn(CanvasGroup panel)
    {
        panel.gameObject.SetActive(true);

        panel.alpha = 0f;

        while (panel.alpha < 1f)
        {
            panel.alpha += Time.deltaTime;

            yield return null;
        }

        panel.alpha = 1f;
    }
}
