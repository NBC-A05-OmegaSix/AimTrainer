using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipTutorialBtn : MonoBehaviour
{
    public void OnSkipTutorialBtn()
    {
        SceneManager.LoadScene("MainScene");
    }
}
