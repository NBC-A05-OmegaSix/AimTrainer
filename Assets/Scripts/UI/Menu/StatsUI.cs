using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int totalShotsFired = 0;
    public int totalShotsHit = 0;
    public TextMeshProUGUI shotsFiredText;
    public TextMeshProUGUI shotsHitText;
    public TextMeshProUGUI timeText; // 시간을 표시할 UI 텍스트

    private bool timerStarted = false;
    private float elapsedTime = 0f;

    void Start()
    {
        Gun.OnAmmoCountUpdate += UpdateAmmoCountUI;
        StartTimer(); // 타이머 시작
    }

    void OnDestroy()
    {
        Gun.OnAmmoCountUpdate -= UpdateAmmoCountUI;
    }

    void Update()
    {
        if (timerStarted)
        {
            elapsedTime += Time.deltaTime; // 경과된 시간 증가
            UpdateTimeUI(); // UI에 시간 업데이트
        }
    }

    void UpdateAmmoCountUI(int count)
    {
        shotsFiredText.text = count.ToString(); // UI
        shotsHitText.text = totalShotsHit.ToString(); // Hit Count
    }

    void UpdateTimeUI()
    {
        timeText.text = elapsedTime.ToString("F1"); // 시간을 UI에 업데이트
    }

    void StartTimer()
    {
        timerStarted = true; // 타이머 시작
    }
}
