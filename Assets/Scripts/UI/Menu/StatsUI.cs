using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public int totalShotsFired = 0;
    public int totalShotsHit = 0;
    public TextMeshProUGUI shotsFiredText;
    public TextMeshProUGUI shotsHitText;

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
