using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    public float minCollisionForce = 10.0f; // 최소 충돌 힘
    public float thresholdForce = 5.0f; // 힘이 바뀌는 임계값

    void OnCollisionEnter(Collision collision)
    {
        Vector3 impactForce = collision.relativeVelocity;

        if (impactForce.magnitude > thresholdForce)
        {
            Target target = collision.gameObject.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            // 힘이 바뀌면 총알을 삭제합니다.
            Destroy(gameObject);
        }
    }
}

