//using UnityEngine;
//using TMPro;

//public class TargetSpawnTrigger : MonoBehaviour
//{
//    public int targetPositionIndex;
//    private bool triggered = false;
//    public TextMeshProUGUI sessionMessageText; // 해당 TextMeshProUGUI를 Inspector에서 할당해야 합니다.

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

//            gameObject.SetActive(false); // 트리거 비활성화

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
//        gameObject.SetActive(true); // 트리거 활성화
//    }
//}
