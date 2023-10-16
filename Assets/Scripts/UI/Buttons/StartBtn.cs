using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject statsUI;


    void Start()
    {

    }

    public void OnStartButtonClicked()
    {
        // 게임 시작 로직
        Debug.Log("Game is starting...");
        mainMenu.SetActive(false);
        statsUI.SetActive(true);
    }

}
