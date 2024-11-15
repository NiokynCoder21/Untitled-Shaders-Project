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

        
        if (thisIndex < dialogueData.dialogueLines.Count) // Check if there are more lines to display
        {
            DialogueScriptable.DialogueLine currentLine = dialogueData.dialogueLines[thisIndex];
           
            speakerNameText.text = currentLine.speakerName; // Update UI with the speaker name and dialogue line
            dialogueText.text = currentLine.lineText;
           
            thisIndex++; // Move to the next line for future calls
        }

    }

}
