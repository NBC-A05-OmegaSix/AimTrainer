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
            //Ÿ�� ��Ȱ��ȭ
            gameObject.SetActive(false);

        }
    }

}
