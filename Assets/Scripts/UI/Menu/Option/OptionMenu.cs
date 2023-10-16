using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mouseMenu;
    public GameObject audioMenu;
    public GameObject crossHairMenu;
    public GameObject backBtn;


    void Start()
    {

    }

    public void OnBackToMenuButtonClicked()
    {
        optionsMenu.SetActive(false);
    }

    public void OnMouseButtonClicked()
    {
        mouseMenu.SetActive(true);
        audioMenu.SetActive(false);
        crossHairMenu.SetActive(false);
    }

    public void OnAudioButtonClicked()
    {
        mouseMenu.SetActive(false);
        audioMenu.SetActive(true);
        crossHairMenu.SetActive(false);
    }

    public void OnCrossHairButtonClicked()
    {
        mouseMenu.SetActive(false);
        audioMenu.SetActive(false);
        crossHairMenu.SetActive(true);
    }
}
