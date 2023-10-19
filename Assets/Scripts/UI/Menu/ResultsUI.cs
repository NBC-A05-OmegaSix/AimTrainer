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

    private Gun gunScript; // Gun ��ũ��Ʈ ����
    private Stats statsScript; // Stats ��ũ��Ʈ ����

    void Start()
    {
        gunScript = FindObjectOfType<Gun>(); // Gun ��ũ��Ʈ ã��
        statsScript = FindObjectOfType<Stats>(); // Stats ��ũ��Ʈ ã��
    }

    void Update()
    {
        // totalShotsText�� �߻��� �Ѿ��� ���� ǥ��
        totalShotsText.text = gunScript.bulletCount.ToString();

        // Stats ��ũ��Ʈ���� totalShotsHit ���� ������ ǥ��
            totalHitsText.text = statsScript.totalShotsHit.ToString();

        totalMissesText.text = (gunScript.bulletCount - statsScript.totalShotsHit).ToString();

        float accuracy = statsScript.totalShotsHit > 0 ? ((float)statsScript.totalShotsHit / gunScript.bulletCount) * 100f : 0f;
        accuracyText.text = accuracy.ToString("F1") + "%";

        timeText.text = statsScript.GetElapsedTime().ToString("F1");

    }

    public void DisplayResults(int totalShots, int totalHits)
    {
        // ǥ���� ����
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
