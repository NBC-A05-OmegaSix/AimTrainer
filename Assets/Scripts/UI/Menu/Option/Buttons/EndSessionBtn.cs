using UnityEngine;

public class EndSessionBtn : MonoBehaviour
{
    public GameObject resultsUI;

    public void OnExitButtonClicked()
    {
        Time.timeScale = 0;
        resultsUI.SetActive(true);
    }
}
