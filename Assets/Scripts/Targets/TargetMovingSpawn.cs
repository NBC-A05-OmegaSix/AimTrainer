using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab; // 움직일 타겟 프리팹
    public Transform spawnPoint; // 타겟을 소환할 위치
    public float moveSpeed = 4.0f; // 타겟의 이동 속도

    private GameObject currentTarget; // 현재 타겟

    void Start()
    {
        SpawnMovingTarget();
    }

    void SpawnMovingTarget()
    {
        if (currentTarget != null)
        {
            // 이전 타겟이 있으면 제거
            Destroy(currentTarget);
        }

        // 타겟을 생성하고 위치 설정
        currentTarget = Instantiate(targetPrefab, spawnPoint.position, Quaternion.identity);

        // 타겟에 움직임을 제어하는 스크립트를 추가
        MovingTargetScript movingScript = currentTarget.GetComponent<MovingTargetScript>();
        if (movingScript != null)
        {
            // 움직임 속도 설정
            movingScript.SetMoveSpeed(moveSpeed);
        }
    }
}