using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject statsUI;
    public GameObject ammosUI;

    public void OnStartButtonClicked()
    {
        Time.timeScale = 1f;
        AudioManager.Instance.PlayBGM(0, true);
        Debug.Log("Game is starting...");
        mainMenu.SetActive(false);
        statsUI.SetActive(true);
        ammosUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
