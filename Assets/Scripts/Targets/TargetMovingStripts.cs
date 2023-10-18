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
        // ������ ������ ���⿡ ����
        // �� ���������� �¿�� �����̵��� �մϴ�.
        float horizontalMovement = Mathf.Sin(Time.time) * moveSpeed;
        transform.Translate(new Vector3(horizontalMovement * Time.deltaTime, 0f, 0f));
    }
}


