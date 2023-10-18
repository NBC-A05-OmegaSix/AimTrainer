using UnityEngine;

public class ExitManager : MonoBehaviour
{
    public void OnExitButtonClicked()
    {
        // 게임 종료 로직
        Debug.Log("Game is exiting...");
        Application.Quit();
    }
}
