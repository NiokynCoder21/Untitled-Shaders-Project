using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecker : MonoBehaviour
{
    public GameObject dialougueStuff;
    public DialougeManager manager;
    public MoverDialougue mover;
    public DialogueScriptable data;
    public DialogueScriptable newData;
    public PisserDialogue pisser;
    public DialogueScriptable pisserData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mover")) ////if collide with game object check if it has tag hand torch
        {
            dialougueStuff.gameObject.SetActive(true);

            if (manager != null)
            {
                manager.SetMover(true);
                mover.SetMover(true);
                mover.ChangeDialogueData(newData); //mover data
            }
        }

        else if (other.gameObject.CompareTag("Stayer"))
        {
            dialougueStuff.gameObject.SetActive(true);

            if (manager != null)
            {
                manager.SetStayer(true);
                manager.ChangeDialogueData(data); //stayer data
            }
        }

        else if (other.gameObject.CompareTag("Pisser"))
        {
            dialougueStuff.gameObject.SetActive(true);

            if (pisser != null)
            {
                pisser.SetPisser(true);
                pisser.ChangeDialogueData(pisserData);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Mover")) //if collide with game object check if it has tag hand torch
        {
            dialougueStuff.gameObject.SetActive(true);

            if (manager != null)
            {
                manager.SetMover(true);
                mover.SetMover(true);
            }
        }

        else if (other.gameObject.CompareTag("Stayer"))
        {
            dialougueStuff.gameObject.SetActive(true);

            if (manager != null)
            {
                manager.SetStayer(true);
            }
        }

        else if (other.gameObject.CompareTag("Pisser"))
        {
            dialougueStuff.gameObject.SetActive(true);

            if (pisser != null)
            {
                pisser.SetPisser(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Mover")) //if collide with game object check if it has tag hand torch
        {
            dialougueStuff.gameObject.SetActive(false);

            if (manager != null)
            {
               manager.SetMover(false);
                mover.SetMover(false);
            }
        }

        else  if (other.gameObject.CompareTag("Stayer"))
        {
            dialougueStuff.gameObject.SetActive(false);

            if (manager != null)
            {
                manager.SetStayer(false);
            }
        }

        else if (other.gameObject.CompareTag("Pisser"))
        {
            dialougueStuff.gameObject.SetActive(false);

            if (pisser != null)
            {
                pisser.SetPisser(false);
            }
        }
    }
}
