using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class MoverDialougue :  DialougeManager
{
    private int currentIndex = 0;
    public List<Transform> patrolWaypoints;
    private NavMeshAgent agent;
    private int currentWaypointIndex = 0;
    public GameObject checker;
    public bool hasTalked = false;
    public GameObject dialogueBox;

    public enum EnemyState
    {
        Talk,
        Move,
        Return,
    }

    private EnemyState currentState;

    public override void onSkip(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isMover == true)
            {

                if (currentState == EnemyState.Talk)
                {
                    ShowNextLine();
                }
            }
        }
    }

    public void Update()
    {
        switch (currentState)
        {
            case EnemyState.Talk:
                break;
            case EnemyState.Move:
                MoveUpdate();
                break;
            case EnemyState.Return:
                break;

        }
    }


    public void MoveUpdate()
    {
        if (hasTalked == true)
        {
            if (agent.remainingDistance < 0.5)
            {
                SetNextWayPoint();
            }
          
        }
    }

    public void SetNextWayPoint()
    {
        if (patrolWaypoints.Count == 0) //checks if no waypoints are assigned
        {
            Debug.LogError("No patrol waypoints assigned!"); //if yes then prints to consolse and returns
            return;
        }

        agent.destination = patrolWaypoints[currentWaypointIndex].position; //makes the enemy move towards its current waypoint
        currentWaypointIndex = (currentWaypointIndex + 1) % patrolWaypoints.Count; //this ensure that after the last waypoint the enemy will loop back to the first waypoint assigned 
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

        else
        {
            checker.gameObject.SetActive(false);
            hasTalked = true;
            currentState = EnemyState.Move;
            dialogueBox.gameObject.SetActive(false);
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
        currentState = EnemyState.Talk;
        agent = GetComponent<NavMeshAgent>();
    }

}
