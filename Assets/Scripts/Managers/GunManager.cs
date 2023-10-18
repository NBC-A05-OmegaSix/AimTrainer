using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GameObject prefab1; // 1번 프리팹
    public GameObject prefab2; // 2번 프리팹
    private GameObject currentPrefab; // 현재 프리팹 인스턴스

    void Start()
    {
        // 초기 상태에서는 아무 프리팹도 생성되지 않도록 설정
        currentPrefab = null;
    }

    void Update()
    {
        // 1번 키를 누르면 1번 프리팹을 생성하고, 이미 다른 프리팹이 있다면 제거
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DestroyCurrentPrefab();
            CreatePrefab(prefab1);
        }
        // 2번 키를 누르면 2번 프리팹을 생성하고, 이미 다른 프리팹이 있다면 제거
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DestroyCurrentPrefab();
            CreatePrefab(prefab2);
        }
    }

    void CreatePrefab(GameObject prefab)
    {
        if (prefab != null)
        {
            // 프리팹을 생성하고 현재 프리팹으로 설정
            currentPrefab = Instantiate(prefab);
        }
    }

    void DestroyCurrentPrefab()
    {
        // 현재 프리팹이 존재하면 제거
        if (currentPrefab != null)
        {
            Destroy(currentPrefab);
        }
    }
}