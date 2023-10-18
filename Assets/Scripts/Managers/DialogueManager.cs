using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI DialoguesText;

    [SerializeField] private GameObject tutorialUI;

    private DialogueList dialogueList;
    private int currentDialogueIndex = 0;
    void Start()
    {
        string path = Application.dataPath + "/Dialogues/Dialogues.json";
        string json = File.ReadAllText(path);
        dialogueList = JsonUtility.FromJson<DialogueList>(json);
    }

    void Update()
    {
        if (tutorialUI != null && tutorialUI.activeInHierarchy && Input.GetKeyDown(KeyCode.Return))
            NextDialogue();
    }

    public void DisplayDialogue()
    {
        if (currentDialogueIndex < dialogueList.dialogues.Count)
        {
            nameText.text = dialogueList.dialogues[currentDialogueIndex].name;
            DialoguesText.text = dialogueList.dialogues[currentDialogueIndex].dialogue;

            AudioManager.Instance.PlayerDialogue(currentDialogueIndex);
        }
        else
        {
            Debug.Log("End of dialogues.");
        }
    }

    void NextDialogue()
    {
        currentDialogueIndex++;

        if (currentDialogueIndex >= dialogueList.dialogues.Count)
            SceneManager.LoadScene("MainScene");

        DisplayDialogue();
    }
}