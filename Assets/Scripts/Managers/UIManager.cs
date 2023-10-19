using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject mainMenu;
    public GameObject resultUI; // 추가된 부분

    void Start()
    {
        mainMenu.SetActive(false);
        resultUI.SetActive(false); // 추가된 부분
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ToggleMainMenu();
        }

        // 추가된 부분 
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        if (targets.Length == 0)
        {
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
