using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int totalShotsFired = 0;
    public int totalShotsHit = 0;
    public TextMeshProUGUI shotsFiredText;
    public TextMeshProUGUI shotsHitText;
    public TextMeshProUGUI timeText; // 시간을 표시할 UI 텍스트
    private float timeRemaining = 180f; // 초기 시간 (초 단위)

    private bool timerStarted = false;

    void Start()
    {
        Gun.OnAmmoCountUpdate += UpdateAmmoCountUI;
    }

    private void Update()
    {
        if (timerStarted)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                int seconds = Mathf.RoundToInt(timeRemaining);
                timeText.text = seconds.ToString(); // 시간 업데이트
            }
            else
            {
                // 시간이 종료된 경우의 작업
                // 예를 들어, 게임 종료 또는 다른 동작을 수행할 수 있습니다.
            }
        }
    }

    public void StartTimer()
    {
        timerStarted = true;
    }

    void OnDestroy()
    {
        Gun.OnAmmoCountUpdate -= UpdateAmmoCountUI;
    }

    void UpdateAmmoCountUI(int count)
    {
        shotsFiredText.text = count.ToString(); // UI
    }
}
