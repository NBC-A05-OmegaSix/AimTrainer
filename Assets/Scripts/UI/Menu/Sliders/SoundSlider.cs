using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    [SerializeField] private Slider SFXSlider;

    private void Awake()
    {
        if(SFXSlider != null && AudioManager.Instance != null)
        {
            SFXSlider.value = AudioManager.Instance.sfxVolume;
            SFXSlider.onValueChanged.AddListener(ChangeSFXVolume);
        }
    }

    public void ChangeSFXVolume(float volume)
    {
        AudioManager.Instance.SetSFXVolume(volume);
    }
}
