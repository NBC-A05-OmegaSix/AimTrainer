using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;

     void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.CompareTag("Target"))
         {
            Target target = collision.gameObject.GetComponent<Target>();
             if (target != null)
             {
                 target.TakeDamage(damage);
             }
         }
        // 총알 충돌 후 처리 (예: 총알 소멸)
        // Destroy(gameObject);
     }
}

