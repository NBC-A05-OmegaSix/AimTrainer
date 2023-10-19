using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private GunManager gunManager;
    public TextMeshProUGUI currentAmmoText;
    public TextMeshProUGUI maxAmmoText;
    public TextMeshProUGUI shootingStateText;

    void Start()
    {
        
    }

    void Update()
    {
        Gun currentGun = GetCurrentGun();

        if (currentGun != null)
        {
            currentAmmoText.text = currentGun.RecentAmmo.ToString();
            maxAmmoText.text = currentGun.RecentMaxAmmo.ToString();
            shootingStateText.text = currentGun.currentFireMode.ToString();
        }

    }

    private Gun GetCurrentGun()
    {
        if (gunManager.assaultRifle.activeSelf)
        {
            return gunManager.assaultRifle.GetComponent<Gun>();
        }
        else if (gunManager.sniperRifle.activeSelf)
        {
            return gunManager.sniperRifle.GetComponent<Gun>();
        }

        return null;
    }
}
