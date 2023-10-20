using System;
using System.Collections;
using UnityEngine;

[Serializable]
public enum FireMode
{
    Single, Burst3, FullAuto
}

public class Gun : MonoBehaviour
{
    public int ARAmmo = 30;
    public int SRAmmo = 10;
    public int ARcurrentAmmo;
    public int SRcurrentAmmo;
    public int RecentAmmo;
    public int RecentMaxAmmo;
    public Transform gunBarrel;

    public GameObject bulletPrefab;
    private float bulletSpeed = 40f;
    private float bulletLifetime = 5f;

    private bool isReloading = false;
    private float reloadTime = 3f;

    private float burstInterval = 0.2f;
    public FireMode currentFireMode = FireMode.Single;
    private bool canShoot = true;
    private bool isShooting = false;

    public bool isSniperRifle;
    private float sniperRifleCooldown = 2.5f;
    private bool isSniperCooldownActive = false;

    private Animator gunAnimator;
    private Coroutine countCoroutine = null;

    public delegate void UpdateAmmoCount(int count);
    public static event UpdateAmmoCount OnAmmoCountUpdate;

    public int bulletCount;
    void Start()
    {
        ARcurrentAmmo = ARAmmo;
        SRcurrentAmmo = SRAmmo;
        RecentAmmo = ARcurrentAmmo;
        RecentMaxAmmo = ARAmmo;
        isReloading = false;
        gunAnimator = GetComponent<Animator>();
        bulletCount = 0;
    }

    void Update()
    {
        if (isReloading)
            return;

        if (currentFireMode == FireMode.FullAuto)
        {
            if (Input.GetMouseButtonDown(0) && canShoot)
            {
                if (RecentAmmo > 0)
                {
                    isShooting = true;
                    StartCoroutine(ShootSequence());
                }
                else
                {
                    Reload();
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                isShooting = false;
            }
        }
        else
        {
            if (!isReloading && Input.GetMouseButtonDown(0) && canShoot)
            {
                if (RecentAmmo > 0)
                { 
                    isShooting = true;
                    Shoot();
                    if (isSniperRifle && !isSniperCooldownActive)
                    {
                        canShoot = false;
                        isSniperCooldownActive = true;
                        StartCoroutine(SniperRifleCooldown());
                    }
                }
                else
                {
                    Reload();
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                isShooting = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        

        if (Input.GetKeyDown(KeyCode.B))
        {
            SwitchFireMode();
        }
    }

    void Shoot()
    {
        if (isReloading || Time.timeScale == 0)
        {
            return;
        }
        if (RecentAmmo > 0)
        {
            bulletCount++;
            if (OnAmmoCountUpdate != null)
            {
                OnAmmoCountUpdate(bulletCount);
            }
            if (isShooting)
            {
                if (currentFireMode == FireMode.Single)
                {
                    if (isSniperRifle)
                    {
                        SRcurrentAmmo--;
                        countCoroutine = StartCoroutine(SniperRifleCooldown());
                    }
                    else
                    {
                        ARcurrentAmmo--;
                    }
                    Camera mainCamera = Camera.main;
                    if (mainCamera != null)
                    {
                        if (isSniperRifle)
                        {
                            gunAnimator.Play("SR Animation");
                            AudioManager.Instance.PlaySFX(SoundEffects.Sfx.FireSR);
                        }
                        else
                        {
                            gunAnimator.Play("AR Animation");
                            AudioManager.Instance.PlaySFX(SoundEffects.Sfx.FireAR);
                        }

                        StartCoroutine(ShootBurst(1));
                    }
                }
                else if (currentFireMode == FireMode.Burst3)
                {
                    int shotNumber = Mathf.Min(RecentAmmo, 3);
                    bulletCount += 2;
                    StartCoroutine(ShootBurst(shotNumber));
                }
                else if (currentFireMode == FireMode.FullAuto)
                {
                    ARcurrentAmmo--;
                    RecentAmmo--;
                    Camera mainCamera = Camera.main;
                    if (mainCamera != null)
                    {
                        gunAnimator.Play("AR Animation");
                        Vector3 cameraForward = mainCamera.transform.forward;
                        GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);
                        AudioManager.Instance.PlaySFX(SoundEffects.Sfx.FireAR);
                        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                        bulletRigidbody.velocity = gunBarrel.forward * bulletSpeed;
                        bulletRigidbody.velocity = cameraForward * bulletSpeed;
                        Destroy(bullet, bulletLifetime);
                    }
                }
            }
        }
        else
        {
            Reload();
        }
    }

    IEnumerator ShootSequence()
    {
        while (isShooting)
        {
            if (isReloading)
            {
                break;
            }
            if (RecentAmmo > 0)
            {
                if (!isReloading)
                {
                    Shoot();
                    yield return new WaitForSeconds(burstInterval);
                }
            }
            else
            {
                Reload();
                break;
            }
        }
    }
    void Reload()
    {
        isReloading = true;

        if (isSniperRifle == true)
        {
            AudioManager.Instance.PlaySFX(SoundEffects.Sfx.ReloadSR);
        }
        else if (isSniperRifle == false)
        {
            AudioManager.Instance.PlaySFX(SoundEffects.Sfx.ReloadAR);
        }
        StartCoroutine(ReloadCoroutine());
    }

    IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(reloadTime);
        if (isSniperRifle)
        {
            SRcurrentAmmo = SRAmmo;
            RecentAmmo = SRcurrentAmmo;
            RecentMaxAmmo = SRAmmo;
        }
        else
        {
            ARcurrentAmmo = ARAmmo;
            RecentAmmo = ARcurrentAmmo;
            RecentMaxAmmo = ARAmmo;
        }
        isReloading = false;
    }


    IEnumerator ShootBurst(int shotNumber)
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            Vector3 cameraForward = mainCamera.transform.forward;
            canShoot = false;
            for (int i = 0; i < shotNumber; i++)
            {
                RecentAmmo --; 
                GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);
                if (isReloading == false)
                {
                    AudioManager.Instance.PlaySFX(SoundEffects.Sfx.FireAR);
                }
                gunAnimator.Play("AR Animation");
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                bulletRigidbody.velocity = gunBarrel.forward * bulletSpeed;
                bulletRigidbody.velocity = cameraForward * bulletSpeed;
                Destroy(bullet, bulletLifetime);
                burstInterval = 0.2f;
                if (i < shotNumber - 1)
                {
                    yield return new WaitForSeconds(burstInterval);
                }
            }
            canShoot = true;
        }
    }
    void SwitchFireMode()
    {
        if (isSniperRifle)
        {
            currentFireMode = FireMode.Single;
            return;
        }
        if (currentFireMode == FireMode.Single)
        {
            AudioManager.Instance.PlaySFX(SoundEffects.Sfx.FireSelector);
            currentFireMode = FireMode.FullAuto;
        }
        else if (currentFireMode == FireMode.FullAuto)
        {
            AudioManager.Instance.PlaySFX(SoundEffects.Sfx.FireSelector);
            currentFireMode = FireMode.Burst3;
        }
        else if (currentFireMode == FireMode.Burst3)
        {
            AudioManager.Instance.PlaySFX(SoundEffects.Sfx.FireSelector);
            currentFireMode = FireMode.Single;
        }
    }
    IEnumerator SniperRifleCooldown()
    {
        yield return new WaitForSeconds(sniperRifleCooldown);
        canShoot = true;
        isSniperCooldownActive = false;
    }

    public void CoroutineTest()
    {
        if(countCoroutine != null)
        {
            StopCoroutine(countCoroutine);
            countCoroutine = null;
            canShoot = true;
            isSniperCooldownActive = false;
        }
    }
}
