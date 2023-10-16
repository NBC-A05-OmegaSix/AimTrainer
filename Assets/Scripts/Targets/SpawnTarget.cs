using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    public GameObject targetPrefab;// Ÿ�� �������� ������ ����
    public Vector3 spawnAreaSize; //Ÿ���� ��ȯ�� ����ũ��
    public int numberOfTargets = 1; //������ Ÿ���� ����
    private GameObject currentTarget; //���� Ÿ��
    public float spawnInterval = 5.0f; //Ÿ���� ��ȯ�� �ð� ����
    private float nextSpawnTime = 6.0f; //���� Ÿ�� ��ȯ �ð�
  

    void Start()
    {
        // ���� �ð� �������� Ÿ�� ���� ����
        InvokeRepeating("SpawnRandomTargets", numberOfTargets, spawnInterval);
   

    }

    void Update()
    {
        //�÷��̾ Ÿ���� ������� Ÿ���� �ǰ��ϰ� ���ο� Ÿ�� ����
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == currentTarget)
                {
                    SpawnNewTarget();
                }
            }
        }
        if (Time.time >= nextSpawnTime)
        {
            SpawnNewTarget();
        }
    }

    void SpawnNewTarget()
    {
        if (currentTarget != null)
        {
            // ���� Ÿ���� ������ ����
            Destroy(currentTarget);
        }
    }
        void SpawnRandomTargets()
    {
        for (int i = 0; i < numberOfTargets; i++)
        {
            // ������ ��ġ ���
            float randomX = Random.Range(-20f,20f);
            float randomY = Random.Range(-20f, 20f);
            float randomZ = Random.Range(-5f, 5f);

            Vector3 randomPosition = transform.position + new Vector3(randomX, randomY, randomZ);

            // Ÿ���� ��ȯ
            Instantiate(targetPrefab, randomPosition, Quaternion.identity);

            //���� Ÿ�� ��ȯ �ð� ����
            nextSpawnTime = Time.time + spawnInterval;
          
        }
    }

  




}
