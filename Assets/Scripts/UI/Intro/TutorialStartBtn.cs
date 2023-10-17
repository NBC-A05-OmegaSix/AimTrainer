using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStartBtn : MonoBehaviour
{
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private GameObject tutorialMessageUI;

    public void OnStartDialogue()
    {
        tutorialMessageUI.SetActive(false);
        dialogueUI.SetActive(true);
        DialogueManager.Instance.DisplayDialogue();
    }
}
