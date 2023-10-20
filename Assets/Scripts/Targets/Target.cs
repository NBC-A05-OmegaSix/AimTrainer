using UnityEngine;

public class Target : MonoBehaviour
{
    public int maxHealth = 1;
    private int currentHealth;
    public float respawnTime = 2.0f;
    [SerializeField]
    private bool isMovable;

    [Header("Moving Target")]
    public float moveSpeed = 4.0f;
    public float moveDistance = 10.0f;
    private Vector3 initialPosition;
    private bool movingRight = true;

    private bool isCounted = false;
    public int totalShotsHit = 0;

    private void Start()
    {
        initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0 && !isCounted)
        {
            FindObjectOfType<Stats>().totalShotsHit++;
            totalShotsHit++;
            isCounted = true;
            AudioManager.Instance.PlaySFX(SoundEffects.Sfx.Hit);
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (isMovable)
        {
            MoveTarget();
        }

    }

    private void MoveTarget()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Vector3.Distance(initialPosition, transform.position) > moveDistance)
        {
            if (movingRight) movingRight = false;
            else movingRight = true;
        }
    }
}
