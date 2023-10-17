using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class DialogueManager : Singleton<DialogueManager>
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptsText;

    private DialogueList dialogueList;
    private int currentDialogueIndex = 0;
    void Start()
    {
        string path = Application.dataPath + "/Dialogues/Dialogues.json";
        string json = File.ReadAllText(path);
        dialogueList = JsonUtility.FromJson<DialogueList>(json);

        DisplayDialogue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            NextDialogue();
    }

    void DisplayDialogue()
    {
        if (currentDialogueIndex < dialogueList.dialogues.Count)
        {
            nameText.text = dialogueList.dialogues[currentDialogueIndex].name;
            descriptsText.text = dialogueList.dialogues[currentDialogueIndex].dialogue;

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