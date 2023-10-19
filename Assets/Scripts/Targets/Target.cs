using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
   
    private AudioSource audiosource;

    public int maxHealth = 1; //타겟 체력
    private int currentHealth;
    public float respawnTime = 2.0f; //타겟 재생성 시간
    private Coroutine respawnCoroutine;
    [SerializeField]
    private bool isMovable;

    [Header("Moving Target")]
    public float moveSpeed = 4.0f; //움직임 속도
    public float moveDistance = 10.0f; //좌우로 움직일 거리
    private Vector3 initialPosition;
    private bool movingRight = true;


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

        if (currentHealth <= 0)
        {
            //타겟 비활성화
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
        //좌우로 움직이는 로직
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        //일정 거리를 이동하면 방향을 바꿈
        if (Vector3.Distance(initialPosition, transform.position) > moveDistance)
        {
            if (movingRight) movingRight = false;
            else movingRight = true;
        }
    }
}
