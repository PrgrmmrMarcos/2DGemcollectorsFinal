// Marcos Acedo 006884833 TeamStrawHat //
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float startTime = 120f; // 2 minute timer //
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private UIManager uiManager; 

    private float currentTime;
    private bool isRunning = true;

    void Start()
    {
        currentTime = startTime;
        UpdateTimerUI();
    }

    void Update()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;
        UpdateTimerUI();

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            isRunning = false;
            uiManager.GameOver(); 
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    public void AddTime(float amount)
    {
        currentTime += amount;
        if (currentTime > 600f) currentTime = 600f; 
        UpdateTimerUI();
    }

    public void StopTimer() => isRunning = false;
    public void ResumeTimer() => isRunning = true;
}
