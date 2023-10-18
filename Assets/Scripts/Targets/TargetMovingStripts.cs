using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTargetScript : MonoBehaviour
{
    private float moveSpeed;

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    void Update()
    {
        // 움직임 로직을 여기에 구현
        // 이 예제에서는 좌우로 움직이도록 합니다.
        float horizontalMovement = Mathf.Sin(Time.time) * moveSpeed;
        transform.Translate(new Vector3(horizontalMovement * Time.deltaTime, 0f, 0f));
    }
}


