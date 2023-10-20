using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private float timeRemaining = 180f;

    private bool timerStarted = false;

    private void Update()
    {
        if (timerStarted)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                int seconds = Mathf.RoundToInt(timeRemaining);
                timeText.text = seconds.ToString();
            }
        }
    }

    public void StartTimer()
    {
        timerStarted = true;
    }
}
