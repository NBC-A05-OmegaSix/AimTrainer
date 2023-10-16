using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public GameObject targetPrefab;
    public float moveSpeed = 4.0f; //������ �ӵ�
    public float moveDistance = 15.0f; //�¿�� ������ �Ÿ�

    private Vector3 initialPosition;
    private bool movingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //�¿�� �����̴� ����
        if(movingRight)
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
