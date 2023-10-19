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
            currentAmmoText.text = gun.RecentAmmo.ToString();
            maxAmmoText.text = gun.RecentMaxAmmo.ToString();
        shootingStateText.text = gun.currentFireMode.ToString();

    }
}
