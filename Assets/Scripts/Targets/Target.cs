using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Target : MonoBehaviour
{
   
    private AudioSource audiosource;

    public int health = 1; //타겟 체력


 
    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        //체력이 0 이하인 경우 타겟 파괴
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    

}
