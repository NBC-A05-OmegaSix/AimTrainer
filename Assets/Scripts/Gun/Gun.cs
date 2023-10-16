using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float reloadTime = 3f; // 리로드 시간 (3초)
    public float burstInterval;
    public enum FireMode
    {
        Single,
        Burst3,
        FullAuto
    }
    public FireMode currentFireMode = FireMode.Single;
    private bool canShoot = true;
    private bool isShooting = false;


    void Start()
    {
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Update()
{
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
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            if (currentAmmo > 0)
            {
                isShooting = true;
                Shoot();
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
        Invoke("Reload", reloadTime);
    }
    Debug.Log("Current Ammo: " + currentAmmo);

    if (Input.GetKeyDown(KeyCode.B))
    {
        SwitchFireMode();
    }
}

void Shoot()
{
    if (currentAmmo > 0)
    {
        if (isShooting)
        {
            if (currentFireMode == FireMode.Single)
            {
                currentAmmo--;
                // 총알 생성
                GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);

                AudioManager.Instance.PlaySFX(SoundEffects.Sfx.FireAR);

                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

                // 총알 초기 속도 설정
                bulletRigidbody.velocity = gunBarrel.forward * bulletSpeed;

                // 총알 발사 후 처리 (예: 총알 소멸 타이머 설정)
                Destroy(bullet, bulletLifetime);
                ShootRay();
            }
            else if (currentFireMode == FireMode.Burst3)
            {
                int shotNumber = Mathf.Min(currentAmmo, 3);
                currentAmmo -= shotNumber;  
                StartCoroutine(ShootBurst(shotNumber));
            }
            else if (currentFireMode == FireMode.FullAuto)
            {
                // 풀오토 모드에서는 무제한 발사 가능
                currentAmmo--;  // 발사마다 총알 소비
                // 총알 생성
                GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                bulletRigidbody.velocity = gunBarrel.forward * bulletSpeed;
                // 총알 발사 후 처리 (예: 총알 소멸 타이머 설정)
                Destroy(bullet, bulletLifetime);
                ShootRay();
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
        if (currentAmmo > 0)
        {
            Shoot();
            yield return new WaitForSeconds(burstInterval);
        }
        else
        {
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

        currentAmmo = maxAmmo;
        isReloading = false;
        // 재장전 애니메이션 실행 및 사운드 플레이
    }
    IEnumerator ShootBurst(int shotNumber)
    {
        canShoot = false;
        for (int i = 0; i < shotNumber; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);            
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = gunBarrel.forward * bulletSpeed;
            Destroy(bullet, bulletLifetime);
            ShootRay();
            burstInterval = 0.1f;
            if (i < shotNumber - 1)
            {
                yield return new WaitForSeconds(burstInterval);
            }
        }
        canShoot = true;
    }
    void SwitchFireMode()
    {
        if (currentFireMode == FireMode.Single)
        {
            Debug.Log("3연사");
            currentFireMode = FireMode.Burst3;
        }
        else if (currentFireMode == FireMode.Burst3)
        {
            Debug.Log("연사");
            currentFireMode = FireMode.FullAuto;
        }
        else if (currentFireMode == FireMode.FullAuto)
        {
            Debug.Log("단발");
            currentFireMode = FireMode.Single;
        }
    }

}

