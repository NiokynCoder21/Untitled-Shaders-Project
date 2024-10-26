using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    public UnityEvent onDialogueTriggered; //this the event
    public DialogueScriptable dialoguedata; //gonna be the thing for each player

    public void TriggerDialogue()
    {
        onDialogueTriggered?.Invoke(); 
    }

    public DialogueScriptable GetDialogueData()
    {
        return dialoguedata;
    } 
}
