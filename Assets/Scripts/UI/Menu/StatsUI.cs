using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int totalShotsFired = 0;
    public int totalShotsHit = 0;
    public TextMeshProUGUI shotsFiredText;
    public TextMeshProUGUI shotsHitText;
    public TextMeshProUGUI timeText;

    private bool timerStarted = false;
    private float elapsedTime = 0f;

    void Start()
    {
        Gun.OnAmmoCountUpdate += UpdateAmmoCountUI;
        StartTimer();
    }

    void OnDestroy()
    {
        Gun.OnAmmoCountUpdate -= UpdateAmmoCountUI;
    }

    void Update()
    {
        if (timerStarted)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimeUI();
        }
    }

    void UpdateAmmoCountUI(int count)
    {
        shotsFiredText.text = count.ToString();
        shotsHitText.text = totalShotsHit.ToString();
    }

    void UpdateTimeUI()
    {
        timeText.text = elapsedTime.ToString("F1");
    }

    void StartTimer()
    {
        timerStarted = true;
    }
    public float GetElapsedTime()
    {
        return elapsedTime;
    }

}
