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

    private Gun gunScript; // Gun 스크립트 참조

    void Start()
    {
        gunScript = FindObjectOfType<Gun>(); // Gun 스크립트 찾기
    }

    void Update()
    {
        // totalShotsText에 발사한 총알의 수를 표시
        totalShotsText.text = gunScript.bulletCount.ToString();

        // 그 외 결과를 표시하는 함수 호출
        //DisplayResults(gunScript.bulletCount, gunScript.totalShotsHit);
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
