using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCheck : MonoBehaviour
{
    public GameObject dialougueStuff;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HandTorch")) ////if collide with game object check if it has tag hand torch
        {
            dialougueStuff.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("HandTorch")) //if collide with game object check if it has tag hand torch
        {
            dialougueStuff.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("HandTorch")) //if collide with game object check if it has tag hand torch
        {
            dialougueStuff.gameObject.SetActive(false);
        }
    }
}
