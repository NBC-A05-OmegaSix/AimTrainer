using UnityEngine;
using TMPro;

public class AmmoUI : MonoBehaviour
{
    public Gun gun; 
    public TextMeshProUGUI currentAmmoText;
    public TextMeshProUGUI maxAmmoText;
    public TextMeshProUGUI shootingStateText;

    void Start()
    {
    }

    void Update()
    {
            currentAmmoText.text = gun.currentAmmo.ToString();
            maxAmmoText.text = gun.maxAmmo.ToString();
        shootingStateText.text = gun.currentFireMode.ToString();

    }
}
