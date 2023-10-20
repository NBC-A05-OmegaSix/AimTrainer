using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipTutorialBtn : MonoBehaviour
{
    public void OnSkipTutorialBtn()
    {
        if(AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(SoundEffects.Sfx.Click);
        }

        SceneManager.LoadScene("MainScene");
    }
}
