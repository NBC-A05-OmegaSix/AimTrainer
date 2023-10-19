using UnityEngine;

public class EndSessionBtn : MonoBehaviour
{
    public GameObject resultsUI;

    public void OnExitButtonClicked()
    {
        Time.timeScale = 0;
        AudioManager.Instance.PlayBGM(0, false);
        resultsUI.SetActive(true);
    }
}
