using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    public GameObject targetPrefab;// 타켓 프리팹을 연결할 변수
    public Vector3 spawnAreaSize; //타켓을 소환할 영역크기
    public int numberOfTargets = 1; //생성할 타겟의 갯수
    private GameObject currentTarget; //현재 타겟
    public float spawnInterval = 5.0f; //타겟을 소환할 시간 간격
    private float nextSpawnTime = 6.0f; //다음 타겟 소환 시간
  

    void Start()
    {
        // 일정 시간 간격으로 타겟 생성 시작
        InvokeRepeating("SpawnRandomTargets", numberOfTargets, spawnInterval);
   

    }

    void Update()
    {
        //플레이어가 타겟을 총을쏘면 타겟을 피격하고 새로운 타겟 생성
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == currentTarget)
                {
                    SpawnNewTarget();
                }
            }
        }
        if (Time.time >= nextSpawnTime)
        {
            SpawnNewTarget();
        }
    }

    void SpawnNewTarget()
    {
        if (currentTarget != null)
        {
            // 이전 타겟이 있으면 제거
            Destroy(currentTarget);
        }
    }
        void SpawnRandomTargets()
    {
        for (int i = 0; i < numberOfTargets; i++)
        {
            // 랜덤한 위치 계산
            float randomX = Random.Range(-20f,20f);
            float randomY = Random.Range(-20f, 20f);
            float randomZ = Random.Range(-5f, 5f);

            Vector3 randomPosition = transform.position + new Vector3(randomX, randomY, randomZ);

            // 타겟을 소환
            Instantiate(targetPrefab, randomPosition, Quaternion.identity);

            //다음 타겟 소환 시간 설정
            nextSpawnTime = Time.time + spawnInterval;
          
        }
    }

  




}
