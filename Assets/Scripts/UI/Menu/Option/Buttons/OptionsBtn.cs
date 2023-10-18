using UnityEngine;
using UnityEngine.UI;

public class OptionsBtn : MonoBehaviour
{
    public GameObject optionsMenu;

    void Start()
    {
    }

    public void OnOptionsButtonClicked()
    {
        optionsMenu.SetActive(true);
    }

}
