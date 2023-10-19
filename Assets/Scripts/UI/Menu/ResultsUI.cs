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
    public GameObject MainMenu;

    private Gun gunScript; // Gun ��ũ��Ʈ ����

    void Start()
    {
        gunScript = FindObjectOfType<Gun>(); // Gun ��ũ��Ʈ ã��
    }

    void Update()
    {
        // totalShotsText�� �߻��� �Ѿ��� ���� ǥ��
        totalShotsText.text = gunScript.bulletCount.ToString();

        // �� �� ����� ǥ���ϴ� �Լ� ȣ��
        //DisplayResults(gunScript.bulletCount, gunScript.totalShotsHit);
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
