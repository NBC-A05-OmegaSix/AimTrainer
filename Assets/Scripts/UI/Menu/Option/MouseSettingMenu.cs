using UnityEngine;
using UnityEngine.UI;

public class MouseSettingMenu : MonoBehaviour
{
    public Slider mouseSensitivitySlider;
    public PlayerCamera playerCamera;

    private void Start()
    {
        mouseSensitivitySlider.onValueChanged.AddListener(delegate { OnSensitivityChanged(); });
    }

    public void OnSensitivityChanged()
    {
        float sensitivityValue = mouseSensitivitySlider.value;
        playerCamera.SetMouseSensitivity(sensitivityValue);
    }
}