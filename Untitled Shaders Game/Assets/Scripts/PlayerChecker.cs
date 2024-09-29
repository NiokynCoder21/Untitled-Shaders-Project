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
    }
}
