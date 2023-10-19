using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GameObject assaultRifle; // 어설트 라이플 오브젝트
    public GameObject sniperRifle;   // 스나이퍼 라이플 오븝젝트
    private GameObject currentPrefab; // 현재 프리팹 인스턴스

    private int currentPrefabType = 0;
    private Gun gunScript;

    void Start()
    {
        sniperRifle.SetActive(false);
        gunScript = assaultRifle.GetComponent<Gun>();
    }

    void Update()
    {
        // 1번 키를 누르면 어설트 라이플 활성화, 2번 키를 누르면 스나이퍼 라이플 활성화
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AudioManager.Instance.PlaySFX(SoundEffects.Sfx.CockingGun);

            // 어설트 라이플 활성화, 스나이퍼 라이플 비활성화
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
            // 어설트 라이플 비활성화, 스나이퍼 라이플 활성화
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
