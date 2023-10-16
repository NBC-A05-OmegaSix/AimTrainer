using UnityEngine;
using UnityEngine.UI;

public class ResultsUI : MonoBehaviour
{
    public Text totalShotsText;
    public Text totalHitsText;
    public Text totalMissesText;
    public Text accuracyText;

    public void DisplayResults(int totalShots, int totalHits)
    {
        totalShotsText.text = totalShots.ToString();
        totalHitsText.text = totalHits.ToString();
        totalMissesText.text = (totalShots - totalHits).ToString();
        float accuracy = totalShots > 0 ? ((float)totalHits / totalShots) * 100f : 0f;
        accuracyText.text = accuracy.ToString("F2") + "%";
    }
}
