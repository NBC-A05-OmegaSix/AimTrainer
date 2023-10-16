using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenTargetPattern : MonoBehaviour
{
    public float hideTime = 2.0f; //은신시간
    public float apperTime = 2.0f; //나타나는 시간

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
            // 은신과 나타남 상태 전환
            isHidden = !isHidden;
            if(isHidden)
            {
                //은신 상태일 때 타겟 비활성화
                //다음 나타나는 시간 설정
                nextActionTime = Time.time + hideTime;
            }
            else
            {

                //다음 은신 시간 설정
                nextActionTime = Time.time + apperTime;
            }
        }
    }
}
