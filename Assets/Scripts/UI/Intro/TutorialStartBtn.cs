using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStartBtn : MonoBehaviour
{
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private GameObject tutorialMessageUI;

    public void OnStartDialogue()
    {
        if(dialogueUI != null && tutorialMessageUI != null)
        {
            tutorialMessageUI.SetActive(false);
            dialogueUI.SetActive(true);
        }
        
        if(DialogueManager.Instance != null)
        {
            DialogueManager.Instance.DisplayDialogue();
        }
    }
}
