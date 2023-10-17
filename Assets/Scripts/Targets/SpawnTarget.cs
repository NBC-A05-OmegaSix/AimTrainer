using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    public GameObject targetPrefab; // Ÿ�� ������
    public Transform targetPosition; // Ÿ���� ������ ��ġ

    void Start()
    {
        // ������ �� Ÿ���� �����ϰ� ��ġ ����
        TargetSpawn(targetPosition.position);
    }

    void TargetSpawn(Vector3 position)
    {
        // Ÿ���� �����ϰ� ��ġ ����
        GameObject newTarget = Instantiate(targetPrefab, position, Quaternion.identity);

        // ���⿡�� Ÿ���� �ʱ�ȭ�ϰų� �߰����� �۾��� ������ �� �ֽ��ϴ�.

        // ������ Ÿ���� ���ϴ� ��ġ�� �̵��ϰų� ������ �� �ֽ��ϴ�.
    }
}