using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    public GameObject targetPrefab; // 타겟 프리팹
    public Transform targetPosition; // 타겟을 생성할 위치

    void Start()
    {
        // 시작할 때 타겟을 생성하고 위치 설정
        TargetSpawn(targetPosition.position);
    }

    void TargetSpawn(Vector3 position)
    {
        // 타겟을 생성하고 위치 설정
        GameObject newTarget = Instantiate(targetPrefab, position, Quaternion.identity);

        // 여기에서 타겟을 초기화하거나 추가적인 작업을 수행할 수 있습니다.

        // 생성한 타겟을 원하는 위치로 이동하거나 조작할 수 있습니다.
    }
}