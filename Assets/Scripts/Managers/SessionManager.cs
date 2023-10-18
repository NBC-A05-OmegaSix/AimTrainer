using UnityEngine;

public class SessionManager : MonoBehaviour
{
    public float sessionDuration = 180f; // ������ ���� �ð�
    public float restartDelay = 5f; // ���� ����� ������

    private float sessionTimer;
    private bool isSessionActive = false;
    private bool isRestarting = false;

    public ResultsUI resultsUI; // ResultsUI ����

    void Start()
    {
        sessionTimer = sessionDuration;
    }

    void Update()
    {
        if (!isSessionActive && Input.GetKeyDown(KeyCode.Space))
        {
            StartSession();
        }

        if (isSessionActive)
        {
            sessionTimer -= Time.deltaTime;

            if (sessionTimer <= 0)
            {
                EndSession();
            }
        }

        if (isRestarting)
        {
            restartDelay -= Time.deltaTime;

            if (restartDelay <= 0)
            {
                StartSession();
                isRestarting = false;
            }
        }
    }

    public void StartSession1()
    {
        Debug.Log("Starting Training Session 1");
        StartSession();
    }

    public void StartSession2()
    {
        Debug.Log("Starting Training Session 2");
        StartSession();
    }

    public void StartSession3()
    {
        Debug.Log("Starting Training Session 3");
        StartSession();
    }

    private void StartSession()
    {
        isSessionActive = true;
        sessionTimer = sessionDuration;
    }

    private void EndSession()
    {
        isSessionActive = false;
        resultsUI.ActivateUI(); // ResultsUI Ȱ��ȭ
        isRestarting = true;
    }
}
