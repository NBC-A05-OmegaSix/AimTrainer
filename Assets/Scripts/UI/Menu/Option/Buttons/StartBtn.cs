using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject statsUI;
    public GameObject ammosUI;


    void Start()
    {

    }

    public void OnStartButtonClicked()
    {
        Time.timeScale = 1f;
        AudioManager.Instance.PlayBGM(0, true);
        // 게임 시작 로직
        Debug.Log("Game is starting...");
        mainMenu.SetActive(false);
        statsUI.SetActive(true);
        ammosUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
