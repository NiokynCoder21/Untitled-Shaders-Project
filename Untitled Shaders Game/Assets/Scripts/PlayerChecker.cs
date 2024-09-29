using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecker : MonoBehaviour
{
    public GameObject dialougueStuff;
    public DialougeManager manager;
    public MoverDialougue mover;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mover")) ////if collide with game object check if it has tag hand torch
        {
            dialougueStuff.gameObject.SetActive(true);

            if (manager != null)
            {
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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Mover")) //if collide with game object check if it has tag hand torch
        {
            dialougueStuff.gameObject.SetActive(true);

            if (manager != null)
            {
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
