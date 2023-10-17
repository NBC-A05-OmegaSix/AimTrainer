using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] private Slider BGMSlider;

    private void Awake()
    {
        if(BGMSlider != null && AudioManager.Instance != null)
        {
            BGMSlider.value = AudioManager.Instance.bgmVolume;
            BGMSlider.onValueChanged.AddListener(ChangeBGMVolume);
        }
    }

    public void ChangeBGMVolume(float volume)
    {
        AudioManager.Instance.SetBGMVolume(volume);
    }
}
