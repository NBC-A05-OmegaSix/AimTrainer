using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovingSpawn : MonoBehaviour
{
    public GameObject targetPrefab; // 타겟 프리팹
    public Transform targetPosition; // 타겟을 생성할 위치
    public float moveSpeed = 4.0f; //움직임 속도
    public float moveDistance = 10.0f; //좌우로 움직일 거리
    private Vector3 initialPosition;
    private bool movingRight = true;
    void Start()
    {
        // 시작할 때 타겟을 생성하고 위치 설정
        TargetSpawn(targetPosition.position);
        initialPosition = transform.position;
    }

    void TargetSpawn(Vector3 position)
    {
        // 타겟을 생성하고 위치 설정
        GameObject newTarget = Instantiate(targetPrefab, position, Quaternion.identity);

        // 여기에서 타겟을 초기화하거나 추가적인 작업을 수행할 수 있습니다.

        // 생성한 타겟을 원하는 위치로 이동하거나 조작할 수 있습니다.

    }
   

    void Update()
    {
        //좌우로 움직이는 로직
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        //일정 거리를 이동하면 방향을 바꿈
        if (Vector3.Distance(initialPosition, transform.position) >= moveDistance)
        {
            movingRight = !movingRight;
        }
    }
}