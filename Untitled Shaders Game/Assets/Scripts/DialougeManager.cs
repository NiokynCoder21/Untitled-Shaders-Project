using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class DialougeManager : MonoBehaviour
{
    public TMP_Text dialogueText; // Display the dialogue text
    public TMP_Text speakerNameText; // Reference to the player's name text GameObject

   // private List<DialogueLine> dialogueLines;
   // private List<PlayerLine> playerLines;
    private int currentLineIndex = 0;

    public DialogueScriptable dialogueData;
    public bool isMover = false;
    public bool isStayer = false;
    public bool isOne = true;

    public virtual void onSkip(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SkipWords();
        }
    }


    public virtual void Start()
    {
        Begin();
    }

    public void Begin()
    {
        ShowNextLine();
    }

  
    public virtual void ShowNextLine()
    {
        if (currentLineIndex < dialogueData.dialogueLines.Count) // Checks if there is any more dialogue to display
        {
            //DialogueLine  // Get the current line
            DialogueScriptable.DialogueLine currentLine = dialogueData.dialogueLines[currentLineIndex];

            speakerNameText.text = currentLine.speakerName;
            dialogueText.text = currentLine.lineText; // Show the next line of dialogue
            currentLineIndex++; // Move to the next line
        }

    }

    public virtual void Reset()
    {
        currentLineIndex = 0;
    }

    public virtual void SkipWords()
    {
        if (isStayer == true)
        {
            ShowNextLine();
        }

    }

    public virtual void ChangeDialogueData(DialogueScriptable newDialogueData)
    {
        dialogueData = newDialogueData; // Update the current dialogue data
        Reset(); // Reset the index to start from the first line of the new dialogue
        ShowNextLine(); // Show the first line of the new dialogue
    }

    public virtual void SetMover(bool state)
    {
        isMover = state;
    }

    public virtual void SetStayer(bool state)
    {
        isStayer = state;
    }

    public virtual void SetOne(bool state)
    {
        isOne = state;
    }
}



// Structure to hold dialogue lines and speaker information
//[System.Serializable]
/*public class DialogueLine
{
    public string lineText; // The dialogue text
    public string speakerName;

    public DialogueLine(string text, string name)
    {
        lineText = text; // Assign text
        speakerName = name;
    }

}

[System.Serializable]
public class PlayerLine
{
    public string lineText; // The dialogue text
    public string speakerName;

    public PlayerLine(string text, string name)
    {
        lineText = text; // Assign text
        speakerName = name;
    }

}*/

