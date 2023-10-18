using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetSpawnManager : Singleton<TargetSpawnManager>
{
    [SerializeField]
    private GameObject targetSpawnPositions;

    public List<Transform> targetPositionGroup;

    [SerializeField]
    private List<GameObject> targetPool = new List<GameObject>();
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private int maxTargets;

    void Start()
    {
        Transform _targetPos = targetSpawnPositions.GetComponentInChildren<Transform>();

        foreach (Transform position in _targetPos)
        {
            targetPositionGroup.Add(position);
        }

        CreateTargetPool();

        FirstGenerateTarget();

        InvokeRepeating(nameof(CreateTarget), 3.0f, 3.0f);
    }

    private void FirstGenerateTarget()
    {
        for (int i = 0; i < maxTargets; i++)
        {
            CreateTarget(i);
        }
    }

    private void CreateTarget(int index)
    {
        var _target = GetTargetPosition();

        _target?.transform.SetPositionAndRotation(targetPositionGroup[index].position, targetPositionGroup[index].rotation);
        _target?.SetActive(true);
    }

    private void CreateTarget()
    {
        int index = Random.Range(0, targetPositionGroup.Count);

        var _target = GetTargetPosition();

        _target?.transform.SetPositionAndRotation(targetPositionGroup[index].position, targetPositionGroup[index].rotation);
        _target?.SetActive(true);
    }

    private GameObject GetTargetPosition()
    {
        foreach (var _target in targetPool)
        {
            if (_target.activeSelf == false)
            {
                return _target;
            }
        }
        return null;
    }

    private void CreateTargetPool()
    {
        for (int i = 0; i < maxTargets; i++)
        {
            GameObject _target = Instantiate(target);
            _target.name = $"target : {i:00}";
            _target.SetActive(false);
            targetPool.Add(_target);
        }
    }
    
}
