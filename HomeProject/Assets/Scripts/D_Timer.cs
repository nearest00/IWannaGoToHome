using TMPro;
using UnityEngine;

public class D_Timer : MonoBehaviour
{
    public D_PLMove PL1;
    public D_PLMove PL2;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float startTime = 120f; 

    private float currentTime;

    private void Start()
    {
        currentTime = startTime;

        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private void Update()
    {
        
        if (D_InputLockManager.IsLocked)
            return;

        currentTime -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        timerText.text = $"{minutes:00}:{seconds:00}";
        if(minutes==0 && seconds == 0)
        {
            D_InputLockManager.Lock();
            PL1.Ending();
            PL2.Ending();
        }
    }
}