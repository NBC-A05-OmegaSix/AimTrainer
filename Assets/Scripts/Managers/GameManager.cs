using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public GameObject mainMenu;
    public GameObject resultUI; // 추가된 부분

    void Start()
    {
        AudioManager.Instance.PlayBGM(0, true);
        Time.timeScale = 1;
        mainMenu.SetActive(false);
        resultUI.SetActive(false); // 추가된 부분
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            AudioManager.Instance.PlayBGM(0, false);
            ToggleMainMenu();
        }

        // 추가된 부분 
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        if (targets.Length == 0)
        {
            Time.timeScale = 0;
            ShowResultUI();
        }
    }

    void ToggleMainMenu()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);

        if (mainMenu.activeSelf)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // 추가된 부분 
    void ShowResultUI()
    {
        resultUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
