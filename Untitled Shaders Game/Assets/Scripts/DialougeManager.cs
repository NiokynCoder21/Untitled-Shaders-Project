using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialougeManager : MonoBehaviour
{
    public TMP_Text dialogueText; //player dialogue

    private List<string> dialogueLines; 
    private int currentLineIndex = 0;

    void Start()
    {
        // Initialize dialogue lines (you can load this from a file or other source)
        dialogueLines = new List<string>(); //create a list that will store all the dialogue lines
        dialogueLines.Add("Oh i skip dialogue with K noice"); //Add dialogue to the list 
        dialogueLines.Add("I need to get moving, the more distance between me and that facility the better, oh are those robots?"); //Add dialogue to the list 
        dialogueLines.Add("Looks I move with A and D, and that green dot shows me something it must be important"); //Add dialogue to the list
        dialogueLines.Add("Wait a second let me press W on one of those robots with the green circle on them, i think i can teleport"); //Add dialogue to the list
        dialogueLines.Add("I cannot feel my legs after being restrained for so long, can i still jump with space"); //Add dialogue to the list
        dialogueLines.Add("I heard one of my captors say i can jump after i teleport, so mid jumping"); //Add dialogue to the list
        dialogueLines.Add("Enough talking, more running now"); //Add dialogue to the list
 
        ShowNextLine();
    }

    void Update()
    {
        // Check for input to advance dialogue
        if (Input.GetKeyDown(KeyCode.K)) //when player presses K
        {
            ShowNextLine();
        }
    }

    void ShowNextLine()
    {
        if (currentLineIndex < dialogueLines.Count) //checks if there is any more player dialogue to display
        {
            dialogueText.text = dialogueLines[currentLineIndex]; //shows the next line of dialogue
            currentLineIndex++;
        }
        else
        {
            dialogueText.text = ""; //hide text when dialouge is finnished
        }
    }

}

