using UnityEngine;
using TMPro;

public class MouseSettingMenu : MonoBehaviour
{
    public TMP_InputField mouseSensitivityInputField;
    public PlayerCamera playerCamera;

    private void Start()
    {
        mouseSensitivityInputField.onEndEdit.AddListener(delegate { OnSensitivityChanged(); });
    }

    public void OnSensitivityChanged()
    {
        if (float.TryParse(mouseSensitivityInputField.text, out float sensitivityValue))
        {
            playerCamera.SetMouseSensitivity(sensitivityValue);
        }
    }
}
