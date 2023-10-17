using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultsUI : MonoBehaviour
{
    public TextMeshProUGUI totalShotsText;
    public TextMeshProUGUI totalHitsText;
    public TextMeshProUGUI totalMissesText;
    public TextMeshProUGUI accuracyText;
    public GameObject ReportMenu;

    public void DisplayResults(int totalShots, int totalHits)
    {
        totalShotsText.text = totalShots.ToString();
        totalHitsText.text = totalHits.ToString();
        totalMissesText.text = (totalShots - totalHits).ToString();
        float accuracy = totalShots > 0 ? ((float)totalHits / totalShots) * 100f : 0f;
        accuracyText.text = accuracy.ToString("F2") + "%";
    }

    public void OnExitButtonClicked()
    {
        ReportMenu.SetActive(false);
    }

}
