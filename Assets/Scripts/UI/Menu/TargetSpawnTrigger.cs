using UnityEngine;

public class TargetSpawnTrigger : MonoBehaviour
{
    public int targetPositionIndex;
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            Debug.Log("Player");

            TargetSpawnManager targetSpawnManager = FindObjectOfType<TargetSpawnManager>();
            if (targetSpawnManager != null)
            {
                targetSpawnManager.SetTargetGroup(targetPositionIndex);
            }

            gameObject.SetActive(false); // 트리거 비활성화
        }
    }

    public void ActivateTrigger()  // 나중에 타겟스폰매니저에서 현재 타겟 수가 0이 되면 ActivateTrigger를 활성화시켜 트리거를 다시 활성화해야함.
    {
        triggered = false;
        gameObject.SetActive(true); // 트리거 활성화
    }
}
