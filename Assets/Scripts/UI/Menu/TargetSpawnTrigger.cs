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

            gameObject.SetActive(false); // Ʈ���� ��Ȱ��ȭ
        }
    }

    public void ActivateTrigger()  // ���߿� Ÿ�ٽ����Ŵ������� ���� Ÿ�� ���� 0�� �Ǹ� ActivateTrigger�� Ȱ��ȭ���� Ʈ���Ÿ� �ٽ� Ȱ��ȭ�ؾ���.
    {
        triggered = false;
        gameObject.SetActive(true); // Ʈ���� Ȱ��ȭ
    }
}
