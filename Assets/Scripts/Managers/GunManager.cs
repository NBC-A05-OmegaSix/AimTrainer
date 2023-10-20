using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GameObject assaultRifle;
    public GameObject sniperRifle;
    private Gun gunScript;

    void Start()
    {
        sniperRifle.SetActive(false);
        gunScript = assaultRifle.GetComponent<Gun>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AudioManager.Instance.PlaySFX(SoundEffects.Sfx.CockingGun);
            if (assaultRifle != null)
            {
                assaultRifle.SetActive(true);
                Gun gunScript = assaultRifle.GetComponent<Gun>();
                if (gunScript != null)
                {
                    gunScript.RecentAmmo = gunScript.ARcurrentAmmo;
                    gunScript.RecentMaxAmmo = gunScript.ARAmmo;
                }
            }
            if (sniperRifle != null)
            {
                sniperRifle.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AudioManager.Instance.PlaySFX(SoundEffects.Sfx.CockingGun);
            if (assaultRifle != null)
            {
                assaultRifle.SetActive(false);
            }
            if (sniperRifle != null)
            {
                sniperRifle.SetActive(true);
                Gun gunScript = sniperRifle.GetComponent<Gun>();
                if (gunScript != null)
                {
                    gunScript.RecentAmmo = gunScript.SRcurrentAmmo;
                    gunScript.RecentMaxAmmo = gunScript.SRAmmo;
                    gunScript.CoroutineTest();
                }
            }
        }
    }
}
