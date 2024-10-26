using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueStuff : MonoBehaviour
{
    public static DialogueStuff Instance { get; private set; }
    public TMP_Text speakerNameText;
    public TMP_Text dialogueText;
    private DialogueScriptable dialogueData;
    private int thisIndex = 0;

    private void Awake()
    {
        // Ensure there's only one instance of DialogueManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Optional: If you want this instance to persist across scenes
        DontDestroyOnLoad(gameObject);
    }


    public void StartDialogue(DialogueScriptable data)
    {
        dialogueData = data;    // Set the dialogue data
        thisIndex = 0;          // Reset the line index

        Debug.Log("Starting dialogue with data: " + data.name);

        ShowNextLine(data);         // Display the first line of dialogue
    }



    public void ShowNextLine(DialogueScriptable data)
    {
        dialogueData = data;

        // Check if there are more lines to display
        if (thisIndex < dialogueData.dialogueLines.Count)
        {
            DialogueScriptable.DialogueLine currentLine = dialogueData.dialogueLines[thisIndex];

            // Update UI with the speaker name and dialogue line
            speakerNameText.text = currentLine.speakerName;
            dialogueText.text = currentLine.lineText;

            // Move to the next line for future calls
            thisIndex++;
        }

    }

}
