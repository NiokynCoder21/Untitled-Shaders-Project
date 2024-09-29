using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialougeManager : MonoBehaviour
{
    public TMP_Text dialogueText; // Display the dialogue text
    public TMP_Text speakerNameText; // Reference to the player's name text GameObject
    public GameObject textStuff;

    private List<DialogueLine> dialogueLines;
    private List<PlayerLine> playerLines;
    private int currentLineIndex = 0;


    void Start()
    {
        // Initialize dialogue lines (you can load this from a file or other source)
        dialogueLines = new List<DialogueLine>(); // Create a list that will store all the dialogue lines

        // Add dialogue lines with the speaker
        dialogueLines.Add(new DialogueLine("Hello there I am tourist, what is this place?", "Thabo")); // Player speaks
        dialogueLines.Add(new DialogueLine("A tourist, man as if there was not enough problems here already", "James")); // Player speaks
        dialogueLines.Add(new DialogueLine("Problems what problems since I am here might as well help", "Thabo")); // Player speaks
        dialogueLines.Add(new DialogueLine("Well, why not this place is The Hotel it is where me and some others have called home", "James")); // Player speaks
        dialogueLines.Add(new DialogueLine("It is not much but for an adandonded area it pretty great in my opioin, but we do have a problem", "James")); // Player speaks
        dialogueLines.Add(new DialogueLine("The Hotel, I hope you do not mind me recording this", "Thabo")); // Player speaks
        dialogueLines.Add(new DialogueLine("Not really but others might just try not to record people who do not want to be recorded", "James")); // Player speaks
        dialogueLines.Add(new DialogueLine("now the problem is recently we had all of the children in The Hotel have gone missing.", "James")); // Player speaks
        dialogueLines.Add(new DialogueLine("Wait what!?", "Thabo")); // Player speaks
        dialogueLines.Add(new DialogueLine("That is horrible I know I said I can help but this seems like a major problem, why trust me", "Thabo")); // Player speaks
        dialogueLines.Add(new DialogueLine("To be honest the rest of the people in The Hotel are distraught and you see, my people and I are", "James")); // Player speaks
        dialogueLines.Add(new DialogueLine("cowards. That is why we are here to escape from the normal life in the towns and cities but our kids deserve better", "James")); // Player speaks
        dialogueLines.Add(new DialogueLine("Fine, I will help but for the kids. Where do I start looking", "Thabo")); // Player speaks
        dialogueLines.Add(new DialogueLine("You should find a letter it will help, the others say they are mutltiple.", "James")); // Player speaks
        dialogueLines.Add(new DialogueLine("They are connected to the kids find them and find the kids. And if you need some help finding", "James")); // Player speaks
        dialogueLines.Add(new DialogueLine("torches talk to one of the other people they can guide you to them if you ask", "James")); // Player speaks
        dialogueLines.Add(new DialogueLine("And thank you stranger may your courage guide you", "James")); // Player speaks

        playerLines = new List<PlayerLine>();

        playerLines.Add(new PlayerLine("Man it is dark down here", "Thabo"));

        ShowNextLine(); // Show the first line of dialogue
    }

    void Update()
    {
        // Check for input to advance dialogue
        if (Input.GetKeyDown(KeyCode.K)) // When player presses K
        {
            ShowNextLine(); // Show the next line of dialogue
        }
    }

    void ShowNextLine()
    {
        if (currentLineIndex < dialogueLines.Count) // Checks if there is any more dialogue to display
        {
            DialogueLine currentLine = dialogueLines[currentLineIndex]; // Get the current line

            speakerNameText.text = currentLine.speakerName;
            dialogueText.text = currentLine.lineText; // Show the next line of dialogue
            currentLineIndex++; // Move to the next line
        }

    }

}



// Structure to hold dialogue lines and speaker information
[System.Serializable]
public class DialogueLine
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

}

