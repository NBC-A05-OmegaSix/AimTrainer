using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private float timeRemaining = 180f; // 초기 시간 (초 단위)

    private bool timerStarted = false;

    private void Update()
    {
        if (timerStarted)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                int seconds = Mathf.RoundToInt(timeRemaining);
                timeText.text = seconds.ToString(); // 텍스트 업데이트
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
}
