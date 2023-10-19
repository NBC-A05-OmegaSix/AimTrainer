using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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

    public delegate void AllTargetsDestroyed();
    public static event AllTargetsDestroyed OnAllTargetsDestroyed;

    void Start()
    {
        //Transform _targetPos = targetSpawnPositions.GetComponentInChildren<Transform>();

        //foreach (Transform position in _targetPos)
        //{
        //    targetPositionGroup.Add(position);
        //    maxTargets++;
        //}

        //CreateTargetPool();

        //FirstGenerateTarget();

        //InvokeRepeating(nameof(CreateTarget), 3.0f, 3.0f); // MainScene ���� �� Ÿ�� ���� �޼���
        SetTargetGroup();
    }
    private void CheckAllTargetsDestroyed()
    {
        foreach (var target in targetPool)
        {
            if (target.activeSelf)
            {
                return;
            }
        }
        OnAllTargetsDestroyed?.Invoke();
    }

    private void FirstGenerateTarget() // MainScene ���� �� �ʱ� Ÿ�� ǥ�� Ȱ��ȭ �޼���. ��� Ÿ�� ��ġ�� Ÿ�� Ȱ��ȭ
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

    private void CreateTarget() // Ÿ�� ��Ȱ��ȭ ���� ��Ȱ��ȭ �޼���, ���� ��Ȱ��ȭ�� Ÿ���� ��Ȱ��ȭ�� �� �ٸ� ��ġ���� �ٸ� Ÿ�ٰ� ��ģ ���¿��� Ȱ��ȭ�Ǵ� ���� �߻�
    {
        int index = Random.Range(0, targetPositionGroup.Count); // �궧��

        var _target = GetTargetPosition();

        _target?.transform.SetPositionAndRotation(targetPositionGroup[index].position, targetPositionGroup[index].rotation);
        _target?.SetActive(true);
    }

    private GameObject GetTargetPosition() // Ÿ�� Ȱ��ȭ ���� üũ, ��Ȱ��ȭ �� �ش� Ÿ�� ��ȯ
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

    private void CreateTargetPool() // Ÿ�� Ǯ ���� �޼���
    {
        for (int i = 0; i < maxTargets; i++)
        {
            GameObject _target = Instantiate(target);
            _target.name = $"target : {i:00}";
            _target.SetActive(false);
            targetPool.Add(_target);
        }
    }

    private void SetTargetGroup() // �÷��̾��� ��ġ�� ���� Ÿ�� �׷��� �ٲ�� �޼���
    {
        ResetTargetGroup();

        _targetPos = targetSpawnPositions[0].GetComponentInChildren<Transform>(); // ����ϴ� ����

        foreach (Transform position in _targetPos)
        {
            targetPositionGroup.Add(position);
            maxTargets++;
        }

        CreateTargetPool();

        FirstGenerateTarget();

        //InvokeRepeating(nameof(CreateTarget), 3.0f, 3.0f);
    }

    private void ResetTargetGroup() // ������ Ÿ�� �׷��� ����ϰ� ���� Ÿ�� �׷��� ����ǵ��� �ʱ�ȭ�ϴ� �޼���
    {
        CancelInvoke();

        if (targetPositionGroup.Count > 0)
        {
            targetPositionGroup.RemoveAll(x => x);
        }

        if (targetPool.Count > 0)
        {
            targetPool.RemoveAll(x => x); // ??
        }

        maxTargets = 0;
    }
}
