using UnityEngine;
using UnityEngine.UI;

public class CrosshairSettingMenu : MonoBehaviour
{
    public Image crosshairImage;
    public Slider scaleSlider;

    public void AdjustCrosshairScale()
    {
        float newScale = scaleSlider.value; 
        crosshairImage.rectTransform.localScale = new Vector3(newScale, newScale, 1);
    }
}
