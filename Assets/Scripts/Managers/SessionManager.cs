using UnityEngine;

public class SessionManager : MonoBehaviour
{
    public ResultsUI resultsUI;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.CompareTag("Session1"))
            {
                StartSession1();
            }
            else if (other.CompareTag("Session2"))
            {
                StartSession2();
            }
            else if (other.CompareTag("Session3"))
            {
                StartSession3();
            }
        }
    }

    public void StartSession1()
    {
    }

    public void StartSession2()
    {
    }

    public void StartSession3()
    {
    }
}
