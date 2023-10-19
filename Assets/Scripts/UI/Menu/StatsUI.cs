using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int totalShotsFired = 0;
    public int totalShotsHit = 0;
    public TextMeshProUGUI shotsFiredText;
    public TextMeshProUGUI shotsHitText;
    public TextMeshProUGUI timeText; // �ð��� ǥ���� UI �ؽ�Ʈ

    private bool timerStarted = false;
    private float elapsedTime = 0f;

    void Start()
    {
        Gun.OnAmmoCountUpdate += UpdateAmmoCountUI;
        StartTimer(); // Ÿ�̸� ����
    }

    void OnDestroy()
    {
        Gun.OnAmmoCountUpdate -= UpdateAmmoCountUI;
    }

    void Update()
    {
        if (timerStarted)
        {
            elapsedTime += Time.deltaTime; // ����� �ð� ����
            UpdateTimeUI(); // UI�� �ð� ������Ʈ
        }
    }

    void UpdateAmmoCountUI(int count)
    {
        shotsFiredText.text = count.ToString(); // UI
        shotsHitText.text = totalShotsHit.ToString(); // Hit Count
    }

    void UpdateTimeUI()
    {
        timeText.text = elapsedTime.ToString("F1"); // �ð��� UI�� ������Ʈ
    }

    void StartTimer()
    {
        timerStarted = true; // Ÿ�̸� ����
    }
}
