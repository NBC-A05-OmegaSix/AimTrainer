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
        // ���� ���� ����
        Debug.Log("Game is starting...");
        mainMenu.SetActive(false);
        statsUI.SetActive(true);
        ammosUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

}
