using UnityEngine;

public class SessionTrigger : MonoBehaviour
{
    public string sessionTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SessionManager sessionManager = FindObjectOfType<SessionManager>();
            if (sessionManager != null)
            {
                if (sessionTag == "TrainingSession1")
                {
                    sessionManager.StartSession1();
                }
                else if (sessionTag == "TrainingSession2")
                {
                    sessionManager.StartSession2();
                }
                else if (sessionTag == "TrainingSession3")
                {
                    sessionManager.StartSession3();
                }
            }
        }
    }
}
