using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialougeManager : MonoBehaviour
{
    public TMP_Text dialogueText; // Display the dialogue text
    public GameObject playerNameText; // Reference to the player's name text GameObject
    public GameObject npcNameText; // Reference to the NPC's name text GameObject

    private List<DialogueLine> dialogueLines;
    private int currentLineIndex = 0;

    void Start()
    {
        // Initialize dialogue lines (you can load this from a file or other source)
        dialogueLines = new List<DialogueLine>(); // Create a list that will store all the dialogue lines

        // Add dialogue lines with the speaker
        dialogueLines.Add(new DialogueLine("Oh I skip dialogue with K, noice", true)); // Player speaks
        dialogueLines.Add(new DialogueLine("I need to get moving, the more distance between me and that facility the better, oh are those robots?", false)); // Player speaks
        dialogueLines.Add(new DialogueLine("Looks like I move with A and D, and that green dot shows me something it must be important", true)); // Player speaks
        dialogueLines.Add(new DialogueLine("Wait a second, let me press W on one of those robots with the green circle on them, I think I can teleport", true)); // Player speaks
        dialogueLines.Add(new DialogueLine("I cannot feel my legs after being restrained for so long, can I still jump with space?", true)); // Player speaks
        dialogueLines.Add(new DialogueLine("I heard one of my captors say I can jump after I teleport, so mid jumping", true)); // Player speaks
        dialogueLines.Add(new DialogueLine("Enough talking, more running now", true)); // Player speaks

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

            // Toggle name text visibility based on the speaker
            if (currentLine.isPlayerSpeaking)
            {
                playerNameText.SetActive(true);
                npcNameText.SetActive(false);
            }
            else
            {
                playerNameText.SetActive(false);
                npcNameText.SetActive(true);
            }

            dialogueText.text = currentLine.lineText; // Show the next line of dialogue
            currentLineIndex++; // Move to the next line
        }
        else
        {
            dialogueText.text = ""; // Hide text when dialogue is finished
            playerNameText.SetActive(false); // Hide player name text
            npcNameText.SetActive(false); // Hide NPC name text
        }
    }
}

// Structure to hold dialogue lines and speaker information
[System.Serializable]
public class DialogueLine
{
    public string lineText; // The dialogue text
    public bool isPlayerSpeaking; // True if the player is speaking, false if the NPC is speaking

    public DialogueLine(string text, bool playerSpeaking)
    {
        lineText = text; // Assign text
        isPlayerSpeaking = playerSpeaking; // Assign speaker
    }
}

