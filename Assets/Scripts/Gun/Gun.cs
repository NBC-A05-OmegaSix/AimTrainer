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
    // 현재 장탄수
    public int ARAmmo = 30; // 최대 장탄수
    public int SRAmmo = 10; // 최대 장탄수
    public int ARcurrentAmmo; //현재 장탄수
    public int SRcurrentAmmo; //현재 장탄수
    public int RecentAmmo;
    public int RecentMaxAmmo;
    private float damage = 10f; // 총의 데미지
    private float range = 100f; // 사정 거리
    public Transform gunBarrel; // 총구의 위치

    public GameObject bulletPrefab; // 총알 프리팹
    private float bulletSpeed = 10f; // 총알 속도
    private float bulletLifetime = 2.5f; // 총알 생존 시간

    private bool isReloading = false; // 리로드 중인지 여부
    private float reloadTime = 3f; // 리로드 시간 (3초)

    private float burstInterval = 0.2f;
    public FireMode currentFireMode = FireMode.Single;
    private bool canShoot = true;
    private bool isShooting = false;

    public bool isSniperRifle;  // 스나이퍼 라이플 여부
    private float sniperRifleCooldown = 2.5f; // 스나이퍼 라이플 재장전 시간
    private bool isSniperCooldownActive = false;

    private Animator gunAnimator; // 애니메이션 컴포넌트 참조
    private Coroutine countCoroutine = null; //코루틴 관련

    public delegate void UpdateAmmoCount(int count); // UI 
    public static event UpdateAmmoCount OnAmmoCountUpdate; // UI 

    public int bulletCount; // 발사한 총알의 수를 저장할 변수

    void Start()
    {
        ARcurrentAmmo = ARAmmo;
        SRcurrentAmmo = SRAmmo;
        RecentAmmo = ARcurrentAmmo;
        RecentMaxAmmo = ARAmmo;
        isReloading = false;
        gunAnimator = GetComponent<Animator>();
        bulletCount = 0; // UI
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
            // 마우스 버튼을 누르는 순간 재장전 중이라면 Shoot() 함수를 호출하지 않음
            if (!isReloading && Input.GetMouseButtonDown(0) && canShoot)
            {
                if (RecentAmmo > 0)
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
            bulletCount++; // 발사한 총알 수 증가
            Debug.Log("발사한 총알 수: " + bulletCount);
            if (OnAmmoCountUpdate != null)
            {
                OnAmmoCountUpdate(bulletCount); // UI 
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
                        Debug.Log("7");
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
                        Debug.Log("8");
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
                    // 풀오토 모드에서는 무제한 발사 가능
                    Camera mainCamera = Camera.main;
                    if (mainCamera != null)
                    {
                        gunAnimator.Play("AR Animation");
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
                    }
                }
            }
        }
        else
        {
            Reload();
        }
        Debug.Log("남은 총알 수: " + RecentAmmo);

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
            // 메인 카메라의 정면 방향을 구합니다.
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
                // 총알 방향 설정
                bulletRigidbody.velocity = cameraForward * bulletSpeed;
                Destroy(bullet, bulletLifetime);
                //gunAnimator.Play("AR Animation Three");
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
