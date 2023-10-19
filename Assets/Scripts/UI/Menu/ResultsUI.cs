using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultsUI : MonoBehaviour
{
    public TextMeshProUGUI totalShotsText;
    public TextMeshProUGUI totalHitsText;
    public TextMeshProUGUI totalMissesText;
    public TextMeshProUGUI accuracyText;
    public TextMeshProUGUI timeText;

    public GameObject ReportMenu;
    public GameObject MainMenu;

    private Gun gunScript; // Gun 스크립트 참조
    private Stats statsScript; // Stats 스크립트 참조

    void Start()
    {
        gunScript = FindObjectOfType<Gun>(); // Gun 스크립트 찾기
        statsScript = FindObjectOfType<Stats>(); // Stats 스크립트 찾기
    }

    void Update()
    {
        // totalShotsText에 발사한 총알의 수를 표시
        totalShotsText.text = gunScript.bulletCount.ToString();

        // Stats 스크립트에서 totalShotsHit 값을 가져와 표시
            totalHitsText.text = statsScript.totalShotsHit.ToString();

        totalMissesText.text = (gunScript.bulletCount - statsScript.totalShotsHit).ToString();

        float accuracy = statsScript.totalShotsHit > 0 ? ((float)statsScript.totalShotsHit / gunScript.bulletCount) * 100f : 0f;
        accuracyText.text = accuracy.ToString("F1") + "%";

        timeText.text = statsScript.GetElapsedTime().ToString("F1");

    }

    public void DisplayResults(int totalShots, int totalHits)
    {
        // 표시할 내용
    }

    public void ActivateUI()
    {
        ReportMenu.SetActive(true);
    }

    public void OnExitButtonClicked()
    {
        ReportMenu.SetActive(false);
        MainMenu.SetActive(false);
    }
}
