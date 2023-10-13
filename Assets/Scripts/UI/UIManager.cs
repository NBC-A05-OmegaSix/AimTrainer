using UnityEngine;
using UnityEngine.UI;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }
}

public class UIManager : Singleton<UIManager>
{
    public GameObject startMenu;
    public GameObject optionsMenu;
    public GameObject mouseMenu;
    public GameObject audioMenu;
    public GameObject crossHairMenu;
    public Text startText;
    public Text currentOptionText;

    void Start()
    {
        startMenu.SetActive(true);
        optionsMenu.SetActive(false);
        mouseMenu.SetActive(false);
        audioMenu.SetActive(false);
        crossHairMenu.SetActive(false);
        startText = startMenu.transform.Find("Start").Find("startText").GetComponent<Text>();
        GameObject currentOption = optionsMenu.transform.Find("CurrentOption").gameObject;
        currentOptionText = currentOption.transform.Find("CurrentOptionText").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            startMenu.SetActive(true);
        }
    }

    public void OnStartButtonClicked()
    {
        // 게임 시작 로직
        Debug.Log("Game is starting...");
        startMenu.SetActive(false);
        if (startText != null)
        {
            startText.text = "RESUME"; // 텍스트 변경
        }
    }

    public void OnOptionsButtonClicked()
    {
        startMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void OnExitButtonClicked()
    {
        // 게임 종료 로직
        Debug.Log("Game is exiting...");
        Application.Quit();
    }

    public void OnMenuButtonClicked()
    {
        optionsMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    public void OnMouseButtonClicked()
    {
        mouseMenu.SetActive(true);
        audioMenu.SetActive(false);
        crossHairMenu.SetActive(false);
        if (currentOptionText != null)
        {
            currentOptionText.text = "MOUSE";
        }
    }

    public void OnAudioButtonClicked()
    {
        mouseMenu.SetActive(false);
        audioMenu.SetActive(true);
        crossHairMenu.SetActive(false);
        if (currentOptionText != null)
        {
            currentOptionText.text = "AUDIO";
        }
    }

    public void OnCrossHairButtonClicked()
    {
        mouseMenu.SetActive(false);
        audioMenu.SetActive(false);
        crossHairMenu.SetActive(true);
        if (currentOptionText != null)
        {
            currentOptionText.text = "CROSSHAIR";
        }
    }
}
