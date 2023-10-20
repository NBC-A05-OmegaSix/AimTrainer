using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    public float minCollisionForce = 10.0f;
    public float thresholdForce = 5.0f;

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
            Destroy(gameObject);
        }
    }
}

