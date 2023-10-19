using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum FireMode
{
    Single, Burst3, FullAuto
}

public class Gun : MonoBehaviour
{
    public int maxAmmo = 10; // 최대 장탄수
    public int currentAmmo; // 현재 장탄수
    public float damage = 10f; // 총의 데미지
    public float range = 100f; // 사정 거리
    public Transform gunBarrel; // 총구의 위치

    public GameObject bulletPrefab; // 총알 프리팹
    public float bulletSpeed = 10f; // 총알 속도
    public float bulletLifetime = 2f; // 총알 생존 시간

    private bool isReloading = false; // 리로드 중인지 여부
    public float reloadTime = 7f; // 리로드 시간 (3초)

    public float burstInterval;
    public FireMode currentFireMode = FireMode.Single;
    private bool canShoot = true;
    private bool isShooting = false;

    public bool isSniperRifle;  // 스나이퍼 라이플 여부
    private float sniperRifleCooldown = 2.5f; // 스나이퍼 라이플 재장전 시간
    private bool isSniperCooldownActive = false;

    private Animator gunAnimator; // 애니메이션 컴포넌트 참조

    void Start()
    {
        currentAmmo = maxAmmo;
        isReloading = false;
        gunAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isReloading)
            return;

        if (currentFireMode == FireMode.FullAuto)
        {
            if (Input.GetMouseButtonDown(0) && canShoot)
            {
                if (currentAmmo > 0)
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
            // 마우스 버튼을 누르는 순간 재장전 중이라면 Shoot() 함수를 호출하지 않음
            if (!isReloading && Input.GetMouseButtonDown(0) && canShoot)
            {
                if (currentAmmo > 0)
                {
                    isShooting = true;
                    Shoot();

                    // 스나이퍼 라이플의 경우 추가적인 쿨다운 처리
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
            Debug.Log("리로딩 중");
            Reload();
        }

        Debug.Log("Current Ammo: " + currentAmmo);

        if (Input.GetKeyDown(KeyCode.B))
        {
            SwitchFireMode();
        }
    }

    void Shoot()
    {
        if (isReloading)
        {
            return;
        }

        if (currentAmmo > 0)
        {
            if (isShooting)
            {
                if (currentFireMode == FireMode.Single)
                {
                    currentAmmo--;
                    Camera mainCamera = Camera.main;
                    if (mainCamera != null)
                    {
                        if (isSniperRifle)
                        {
                            gunAnimator.Play("SR Animation"); // 스니퍼 라이플 애니메이션 
                            AudioManager.Instance.PlaySFX(SoundEffects.Sfx.FireSR);
                        }
                        else
                        {
                            gunAnimator.Play("AR Animation"); // 기본 발사 애니메이션 클립
                            AudioManager.Instance.PlaySFX(SoundEffects.Sfx.FireAR);
                        }
                        StartCoroutine(ShootBurst(1));
                    }
                }
                else if (currentFireMode == FireMode.Burst3)
                {
                    int shotNumber = Mathf.Min(currentAmmo, 3);
                    currentAmmo -= shotNumber;
                    StartCoroutine(ShootBurst(shotNumber));
                }
                else if (currentFireMode == FireMode.FullAuto)
                {
                    currentAmmo--;
                    // 풀오토 모드에서는 무제한 발사 가능
                    Camera mainCamera = Camera.main;
                    if (mainCamera != null)
                    {
                        // 메인 카메라의 정면 방향을 구합니다.
                        Vector3 cameraForward = mainCamera.transform.forward;
                        // 총알 생성
                        GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);
                        AudioManager.Instance.PlaySFX(SoundEffects.Sfx.FireAR);
                        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                        bulletRigidbody.velocity = gunBarrel.forward * bulletSpeed;
                        // 총알 방향 설정
                        bulletRigidbody.velocity = cameraForward * bulletSpeed;
                        // 총알 발사 후 처리
                        Destroy(bullet, bulletLifetime);
                        ShootRay();
                    }
                }
            }
        }
    }

    void StartShooting()
    {
        isShooting = true;
        StartCoroutine(ShootSequence());
    }
    IEnumerator ShootSequence()
    {
        while (isShooting)
        {
            if (isReloading)
            {
                break;
            }

            if (currentAmmo > 0)
            {
                gunAnimator.SetTrigger("Go");

                if (!isReloading)
                {
                    Shoot();
                    yield return new WaitForSeconds(burstInterval);
                }
            }
            else
            {
                gunAnimator.SetTrigger("turn");
                Reload();

                break;
            }
        }
    }




    void ShootRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(gunBarrel.position, gunBarrel.forward, out hit, range))
        {
            //TakeDamage(damage)함수 필요
        }
    }

    void Reload()
    {
        Debug.Log("리로딩 중");
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

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    IEnumerator ShootBurst(int shotNumber)
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            // 메인 카메라의 정면 방향을 구합니다.
            Vector3 cameraForward = mainCamera.transform.forward;
            canShoot = false;
            for (int i = 0; i < shotNumber; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);
                if (isReloading == false)
                {
                    AudioManager.Instance.PlaySFX(SoundEffects.Sfx.FireAR);
                }
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                bulletRigidbody.velocity = gunBarrel.forward * bulletSpeed;
                // 총알 방향 설정
                bulletRigidbody.velocity = cameraForward * bulletSpeed;
                Destroy(bullet, bulletLifetime);
                ShootRay();
                gunAnimator.Play("AR Animation Three");
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
        // 스나이퍼 라이플이면 단발 모드만 가능
        if (isSniperRifle)
        {
            currentFireMode = FireMode.Single;
            Debug.Log("스나이퍼 라이플은 단발 모드만 가능합니다.");
            return;
        }

        // 다른 경우에 대한 모드 전환 코드는 그대로 유지
        if (currentFireMode == FireMode.Single)
        {
            AudioManager.Instance.PlaySFX(SoundEffects.Sfx.FireSelector);
            Debug.Log("연사");
            currentFireMode = FireMode.FullAuto;
        }
        else if (currentFireMode == FireMode.FullAuto)
        {
            AudioManager.Instance.PlaySFX(SoundEffects.Sfx.FireSelector);
            Debug.Log("3연사");
            currentFireMode = FireMode.Burst3;
        }
        else if (currentFireMode == FireMode.Burst3)
        {
            AudioManager.Instance.PlaySFX(SoundEffects.Sfx.FireSelector);
            Debug.Log("단발");
            currentFireMode = FireMode.Single;
        }
    }
    IEnumerator SniperRifleCooldown()
    {
        yield return new WaitForSeconds(sniperRifleCooldown);
        canShoot = true;
        isSniperCooldownActive = false;
    }
}
