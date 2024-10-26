using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private DialogueTrigger npcNear;
    public GameObject dialogueUI;
    public bool newSpeaker = false;
    public DialogueScriptable dialogueData;

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (npcNear != null)
            {
                DialogueStuff.Instance.ShowNextLine(npcNear.GetDialogueData());
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
        // Check if the player enters the proximity of an NPC tagged appropriately
        var npc = other.GetComponent<DialogueTrigger>();

        if (npc != null)
        {
            dialogueUI.gameObject.SetActive(true);
            npcNear = npc;
            newSpeaker = true;
            print("collion");

            if (newSpeaker == true)
            {
                DialogueStuff.Instance.StartDialogue(npcNear.GetDialogueData());
                newSpeaker = false;
            }
           
        }
    }


    private void OnTriggerExit(Collider other)
    {
        // Clear the NPC reference if the player exits the NPC’s proximity
        if (npcNear != null && other.GetComponent<DialogueTrigger>() == npcNear)
        {
            dialogueUI.gameObject.SetActive(false);
            newSpeaker = false;
            npcNear = null;
            print("exit collion");
        }
    }
}
