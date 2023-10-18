using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab; // ������ Ÿ�� ������
    public Transform spawnPoint; // Ÿ���� ��ȯ�� ��ġ
    public float moveSpeed = 4.0f; // Ÿ���� �̵� �ӵ�

    private GameObject currentTarget; // ���� Ÿ��

    void Start()
    {
        SpawnMovingTarget();
    }

    void SpawnMovingTarget()
    {
        if (currentTarget != null)
        {
            // ���� Ÿ���� ������ ����
            Destroy(currentTarget);
        }

        // Ÿ���� �����ϰ� ��ġ ����
        currentTarget = Instantiate(targetPrefab, spawnPoint.position, Quaternion.identity);

        // Ÿ�ٿ� �������� �����ϴ� ��ũ��Ʈ�� �߰�
        MovingTargetScript movingScript = currentTarget.GetComponent<MovingTargetScript>();
        if (movingScript != null)
        {
            // ������ �ӵ� ����
            movingScript.SetMoveSpeed(moveSpeed);
        }
    }
}