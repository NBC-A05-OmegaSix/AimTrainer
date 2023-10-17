using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stats : MonoBehaviour
{
    public int totalShotsFired = 0;
    public int totalShotsHit = 0;
    public float timeRemaining = 180f;
    public TextMeshProUGUI shotsFiredText;
    public TextMeshProUGUI shotsHitText;
    public TextMeshProUGUI timeRemainingText;
    public GameObject mainMenuUI;

    private bool isPaused = false;

    void Start()
    {
        shotsFiredText.text = "0";
        shotsHitText.text = "0";
        timeRemainingText.text = "180";
    }

    void Update()
    {
        if (mainMenuUI.activeSelf)
        {
            isPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
        }

        if (!isPaused && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timeRemainingText.text = Mathf.Round(timeRemaining).ToString();
        }
    }

    public void IncrementShotsFired()
    {
        totalShotsFired++;
        shotsFiredText.text = totalShotsFired.ToString();
    }

    public void IncrementShotsHit()
    {
        totalShotsHit++;
        shotsHitText.text = totalShotsHit.ToString();
    }
}
