//using UnityEngine;
//using TMPro;

//public class TargetSpawnTrigger : MonoBehaviour
//{
//    public int targetPositionIndex;
//    private bool triggered = false;
//    public TextMeshProUGUI sessionMessageText; // �ش� TextMeshProUGUI�� Inspector���� �Ҵ��ؾ� �մϴ�.

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player") && !triggered)
//        {
//            triggered = true;
//            Debug.Log("Player");

//            TargetSpawnManager targetSpawnManager = FindObjectOfType<TargetSpawnManager>();
//            if (targetSpawnManager != null)
//            {
//                targetSpawnManager.SetTargetGroup(targetPositionIndex);
//            }

//            gameObject.SetActive(false); // Ʈ���� ��Ȱ��ȭ

//            if (sessionMessageText != null)
//            {
//                sessionMessageText.gameObject.SetActive(true);
//                Invoke("HideSessionMessage", 2f);
//            }
//        }
//    }

//    private void HideSessionMessage()
//    {
//        if (sessionMessageText != null)
//        {
//            sessionMessageText.gameObject.SetActive(false);
//        }
//    }

//    public void ActivateTrigger()
//    {
//        triggered = false;
//        gameObject.SetActive(true); // Ʈ���� Ȱ��ȭ
//    }
//}
