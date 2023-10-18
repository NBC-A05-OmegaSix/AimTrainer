using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovingSpawn : MonoBehaviour
{
    public GameObject targetPrefab; // Ÿ�� ������
    public Transform targetPosition; // Ÿ���� ������ ��ġ
    public float moveSpeed = 4.0f; //������ �ӵ�
    public float moveDistance = 10.0f; //�¿�� ������ �Ÿ�
    private Vector3 initialPosition;
    private bool movingRight = true;
    void Start()
    {
        // ������ �� Ÿ���� �����ϰ� ��ġ ����
        TargetSpawn(targetPosition.position);
        initialPosition = transform.position;
    }

    void TargetSpawn(Vector3 position)
    {
        // Ÿ���� �����ϰ� ��ġ ����
        GameObject newTarget = Instantiate(targetPrefab, position, Quaternion.identity);

        // ���⿡�� Ÿ���� �ʱ�ȭ�ϰų� �߰����� �۾��� ������ �� �ֽ��ϴ�.

        // ������ Ÿ���� ���ϴ� ��ġ�� �̵��ϰų� ������ �� �ֽ��ϴ�.

    }
   

    void Update()
    {
        //�¿�� �����̴� ����
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        //���� �Ÿ��� �̵��ϸ� ������ �ٲ�
        if (Vector3.Distance(initialPosition, transform.position) >= moveDistance)
        {
            movingRight = !movingRight;
        }
    }
}