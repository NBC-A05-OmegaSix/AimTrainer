using UnityEngine;

public class ExitManager : MonoBehaviour
{
    public GameObject resultsUI;

    public void OnExitButtonClicked()
    {
        resultsUI.SetActive(true);
    }
}
