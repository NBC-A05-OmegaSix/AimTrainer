using UnityEngine;

public class ExitManager : MonoBehaviour
{
    public void OnExitButtonClicked()
    {
        // ���� ���� ����
        Debug.Log("Game is exiting...");
        Application.Quit();
    }
}
