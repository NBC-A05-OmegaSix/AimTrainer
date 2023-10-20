using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultsUI : MonoBehaviour
{
    public TextMeshProUGUI totalShotsText;
    public TextMeshProUGUI totalHitsText;
    public TextMeshProUGUI totalMissesText;
    public TextMeshProUGUI accuracyText;
    public TextMeshProUGUI timeText;

    public GameObject ReportMenu;
    public GameObject MainMenu;

    private Gun gunScript; 
    private Stats statsScript;

    void Start()
    {
        gunScript = FindObjectOfType<Gun>();
        statsScript = FindObjectOfType<Stats>();
    }

    void Update()
    {
        totalShotsText.text = gunScript.bulletCount.ToString();

            totalHitsText.text = statsScript.totalShotsHit.ToString();

        totalMissesText.text = (gunScript.bulletCount - statsScript.totalShotsHit).ToString();

        float accuracy = statsScript.totalShotsHit > 0 ? ((float)statsScript.totalShotsHit / gunScript.bulletCount) * 100f : 0f;
        accuracyText.text = accuracy.ToString("F1") + "%";

        timeText.text = statsScript.GetElapsedTime().ToString("F1");

    }

    //public void DisplayResults(int totalShots, int totalHits)
    //{
    //}

    public void ActivateUI()
    {
        AudioManager.Instance.PlayBGM(0, false);
        Time.timeScale = 0;
        ReportMenu.SetActive(true);
    }

    public void OnExitButtonClicked()
    {
        SceneManager.LoadScene("MainScene");
        ReportMenu.SetActive(false);
        MainMenu.SetActive(false);
    }
}
