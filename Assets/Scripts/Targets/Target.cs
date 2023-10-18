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

 
    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }


    private void Start()
    {
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

}
