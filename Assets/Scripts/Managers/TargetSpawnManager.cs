using System.Collections.Generic;
using UnityEngine;

public class TargetSpawnManager : Singleton<TargetSpawnManager>
{
    [SerializeField]
    private List<GameObject> targetSpawnPositions;

    public List<Transform> targetPositionGroup;

    [SerializeField]
    private List<GameObject> targetPool = new List<GameObject>();
    [SerializeField]
    private GameObject target;

    private int maxTargets;
    private Transform _targetPos;

    void Start()
    {
        SetTargetGroup();
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

    private void SetTargetGroup() 
    {
        ResetTargetGroup();

        _targetPos = targetSpawnPositions[0].GetComponentInChildren<Transform>();

        foreach (Transform position in _targetPos)
        {
            targetPositionGroup.Add(position);
            maxTargets++;
        }

        CreateTargetPool();

        FirstGenerateTarget();
    }

    private void ResetTargetGroup()
    {
        CancelInvoke();

        if (targetPositionGroup.Count > 0)
        {
            targetPositionGroup.RemoveAll(x => x);
        }
        if (targetPool.Count > 0)
        {
            targetPool.RemoveAll(x => x);
        }
        maxTargets = 0;
    }
}