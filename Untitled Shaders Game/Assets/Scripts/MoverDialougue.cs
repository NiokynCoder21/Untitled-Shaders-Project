using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoverDialougue :  DialougeManager
{
    private int currentIndex = 0;

    public override void onSkip(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isMover == true)
            {
                ShowNextLine();
            }
        }
    }

    public override void ShowNextLine()
    {
        if (currentIndex < dialogueData.dialogueLines.Count) // Checks if there is any more dialogue to display
        {
            //DialogueLine  // Get the current line
            DialogueScriptable.DialogueLine currentLine = dialogueData.dialogueLines[currentIndex];

            speakerNameText.text = currentLine.speakerName; //converts speaker text to name of speaker
            dialogueText.text = currentLine.lineText; // Show the next line of dialogue
            currentIndex++; // Move to the next line
        }

    }

    public override void ChangeDialogueData(DialogueScriptable newDialogueData)
    {
        dialogueData = newDialogueData; // Update the current dialogue data
        currentIndex = 0; //resets the index
        ShowNextLine(); // Show the first line of the new dialogue
    }

    public override void Start()
    {
        ShowNextLine();
    }

}
