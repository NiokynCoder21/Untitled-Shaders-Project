using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PisserDialogue : DialougeManager
{
    private int thisIndex = 0;
    public bool isPisser = false;

    public override void onSkip(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isPisser == true)
            {
                ShowNextLine();
            }
        }
    }

    public override void ShowNextLine()
    {
        if (thisIndex < dialogueData.dialogueLines.Count) // Checks if there is any more dialogue to display
        {
            //DialogueLine  // Get the current line
            DialogueScriptable.DialogueLine currentLine = dialogueData.dialogueLines[thisIndex];

            speakerNameText.text = currentLine.speakerName; //converts speaker text to name of speaker
            dialogueText.text = currentLine.lineText; // Show the next line of dialogue
            thisIndex++; // Move to the next line
        }

    }

    public override void ChangeDialogueData(DialogueScriptable newDialogueData)
    {
        dialogueData = newDialogueData; // Update the current dialogue data
        thisIndex = 0; //resets the index
        ShowNextLine(); // Show the first line of the new dialogue
    }

    public void SetPisser(bool state)
    {
        isPisser = state;
    }
}
