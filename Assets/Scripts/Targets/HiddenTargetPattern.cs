using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenTargetPattern : MonoBehaviour
{
    public float hideTime = 2.0f; //���Žð�
    public float apperTime = 2.0f; //��Ÿ���� �ð�

    private float nextActionTime = 0.0f;
    private bool isHidden = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            // ���Ű� ��Ÿ�� ���� ��ȯ
            isHidden = !isHidden;
            if(isHidden)
            {
                //���� ������ �� Ÿ�� ��Ȱ��ȭ
                //���� ��Ÿ���� �ð� ����
                nextActionTime = Time.time + hideTime;
            }
            else
            {

                //���� ���� �ð� ����
                nextActionTime = Time.time + apperTime;
            }
        }
    }
}
