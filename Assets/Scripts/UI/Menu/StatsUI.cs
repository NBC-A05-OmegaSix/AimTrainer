using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int totalShotsFired = 0;
    public int totalShotsHit = 0;
    public TextMeshProUGUI shotsFiredText;
    public TextMeshProUGUI shotsHitText;
    public TextMeshProUGUI timeText; // �ð��� ǥ���� UI �ؽ�Ʈ
    private float timeRemaining = 180f; // �ʱ� �ð� (�� ����)

    private bool timerStarted = false;

    void Start()
    {
        Gun.OnAmmoCountUpdate += UpdateAmmoCountUI;
    }

    private void Update()
    {
        if (timerStarted)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                int seconds = Mathf.RoundToInt(timeRemaining);
                timeText.text = seconds.ToString(); // �ð� ������Ʈ
            }
            else
            {
                // �ð��� ����� ����� �۾�
                // ���� ���, ���� ���� �Ǵ� �ٸ� ������ ������ �� �ֽ��ϴ�.
            }
        }
    }

    public void StartTimer()
    {
        timerStarted = true;
    }

    void OnDestroy()
    {
        Gun.OnAmmoCountUpdate -= UpdateAmmoCountUI;
    }

    void UpdateAmmoCountUI(int count)
    {
        shotsFiredText.text = count.ToString(); // UI
    }
}
