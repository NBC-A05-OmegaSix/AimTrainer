using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
   
    private AudioSource audiosource;

    public int maxHealth = 1; //Ÿ�� ü��
    private int currentHealth;
    public float respawnTime = 2.0f; //Ÿ�� ����� �ð�
    private Coroutine respawnCoroutine;
    [SerializeField]
    private bool isMovable;

    [Header("Moving Target")]
    public float moveSpeed = 4.0f; //������ �ӵ�
    public float moveDistance = 10.0f; //�¿�� ������ �Ÿ�
    private Vector3 initialPosition;
    private bool movingRight = true;

    private bool isCounted = false; // UI target Count
    public int totalShotsHit = 0;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0 && !isCounted) // Ÿ���� ��Ȱ��ȭ�ǰ� ���� ī��Ʈ���� �ʾ��� ��
        {
            FindObjectOfType<Stats>().totalShotsHit++;
            totalShotsHit++; // Ÿ���� ��Ȱ��ȭ�� Ƚ�� ����
            isCounted = true; // ī��Ʈ�Ǿ����� ǥ��
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
        if (Vector3.Distance(initialPosition, transform.position) > moveDistance)
        {
            if (movingRight) movingRight = false;
            else movingRight = true;
        }
    }
}
