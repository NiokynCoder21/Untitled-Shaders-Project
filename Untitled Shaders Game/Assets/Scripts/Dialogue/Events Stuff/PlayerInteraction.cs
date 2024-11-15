using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private DialogueTrigger npcNear; //holds reference which will help ensure that only 1 npc is near
    public GameObject dialogueUI; //the digualue ui
    public bool newSpeaker = false; //if is talking to npc

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (npcNear != null)
            {
                DialogueStuff.Instance.ShowNextLine(npcNear.GetDialogueData()); //this calls shownext line of current npc skiping through dialigue
                OnEnable();
                OnDisable();
            }

        }
    }

    private void OnEnable()
    {
        if (npcNear != null)
        {
            npcNear.onDialogueTriggered.AddListener(ShowStuff);
        }
    }

    private void OnDisable() //i have these 2 to allow the skip to be called then stop to ensure it does cause a stack overflow 
    {
        if (npcNear != null)
        {
            npcNear.onDialogueTriggered.RemoveListener(ShowStuff); 
        }
    }

    public void ShowStuff()
    {
        npcNear.TriggerDialogue(); //this is what allows player to skip dialogue
    }

    private void OnTriggerEnter(Collider other)
    {
        
        var npc = other.GetComponent<DialogueTrigger>(); // Check if the player enters the proximity of an NPC tagged appropriately

        if (npc != null)
        {
            dialogueUI.gameObject.SetActive(true);
            npcNear = npc;
            newSpeaker = true;

            if (newSpeaker == true)
            {
                DialogueStuff.Instance.StartDialogue(npcNear.GetDialogueData());
                newSpeaker = false;
            }
           
        }
    }


    private void OnTriggerExit(Collider other)
    {      
        if (npcNear != null && other.GetComponent<DialogueTrigger>() == npcNear) // Clear the NPC reference if the player exits the NPC’s proximity
        {
            dialogueUI.gameObject.SetActive(false);
            newSpeaker = false;
            npcNear = null;
            print("exit collion");
        }
    }
}
