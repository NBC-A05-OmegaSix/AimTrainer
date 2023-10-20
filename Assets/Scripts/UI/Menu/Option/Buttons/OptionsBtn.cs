using UnityEngine;

public class OptionsBtn : MonoBehaviour
{
    public GameObject optionsMenu;

    public void OnOptionsButtonClicked()
    {
        optionsMenu.SetActive(true);
    }

}
