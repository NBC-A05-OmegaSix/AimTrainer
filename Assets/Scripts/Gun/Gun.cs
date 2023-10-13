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


    void Start()
    {
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("리로딩 중");
            Invoke("Reload", 3f);
        }
        Debug.Log("Current Ammo: " + currentAmmo);
    }

    void Shoot()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;

            // 총알 생성
            GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            // 총알 초기 속도 설정
            bulletRigidbody.velocity = gunBarrel.forward * bulletSpeed;

            // 총알 발사 후 처리 (예: 총알 소멸 타이머 설정)
            Destroy(bullet, bulletLifetime);
        }
        else
        {
            // 장탄수가 0이면 재장전
            Debug.Log("리로딩 중");
            Invoke("Reload", 3f);
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
}

