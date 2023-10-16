using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Target : MonoBehaviour
{
   
    private AudioSource audiosource;

    public int health = 1; //Ÿ�� ü��


 
    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        //ü���� 0 ������ ��� Ÿ�� �ı�
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    

}
