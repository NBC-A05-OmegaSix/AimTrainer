using UnityEngine;
using UnityEngine.UI;


public class UIManager : Singleton<UIManager>
{
    public GameObject mainMenu;
    void Start()
    {
        mainMenu.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("Option Key Debug");
            mainMenu.SetActive(true);
        }
    }

}
