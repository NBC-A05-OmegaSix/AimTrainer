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

        //InvokeRepeating(nameof(CreateTarget), 3.0f, 3.0f); // MainScene 시작 시 타겟 생성 메서드
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

    private void FirstGenerateTarget() // MainScene 시작 시 초기 타겟 표시 활성화 메서드. 모든 타겟 위치에 타겟 활성화
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

    private void CreateTarget() // 타겟 비활성화 이후 재활성화 메서드, 현재 비활성화된 타겟이 재활성화될 때 다른 위치에서 다른 타겟과 겹친 상태에서 활성화되는 버그 발생
    {
        int index = Random.Range(0, targetPositionGroup.Count); // 얘때문

        var _target = GetTargetPosition();

        _target?.transform.SetPositionAndRotation(targetPositionGroup[index].position, targetPositionGroup[index].rotation);
        _target?.SetActive(true);
    }

    private GameObject GetTargetPosition() // 타겟 활성화 여부 체크, 비활성화 시 해당 타겟 반환
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

    private void CreateTargetPool() // 타겟 풀 생성 메서드
    {
        for (int i = 0; i < maxTargets; i++)
        {
            GameObject _target = Instantiate(target);
            _target.name = $"target : {i:00}";
            _target.SetActive(false);
            targetPool.Add(_target);
        }
    }

    private void SetTargetGroup() // 플레이어의 위치에 따라 타겟 그룹이 바뀌는 메서드
    {
        ResetTargetGroup();

        _targetPos = targetSpawnPositions[0].GetComponentInChildren<Transform>(); // 여깁니다 여기

        foreach (Transform position in _targetPos)
        {
            targetPositionGroup.Add(position);
            maxTargets++;
        }

        CreateTargetPool();

        FirstGenerateTarget();

        //InvokeRepeating(nameof(CreateTarget), 3.0f, 3.0f);
    }

    private void ResetTargetGroup() // 이전의 타겟 그룹을 취소하고 현재 타겟 그룹이 적용되도록 초기화하는 메서드
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
