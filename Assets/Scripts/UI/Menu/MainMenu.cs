using UnityEngine;

public class IntroMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject exitMenu;


    void Start()
    {
    }

    public void OnStartMenuClicked()
    {
        optionsMenu.SetActive(false);
    }

    public void OnOptionsButtonClicked()
    {
        optionsMenu.SetActive(true);
    }


    public void OnExitButtonClicked()
    {

        Debug.Log("Game is exiting...");
        Application.Quit();
    }
}
