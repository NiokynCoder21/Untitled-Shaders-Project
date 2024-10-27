using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{
    public GameObject torch; //this is the torch game object the player is holding
    public GameObject oldTorch; //this the torch colletable that can found in the level

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HandTorch")) //if collide with game object check if it has tag hand torch
        {
            if (!TorchManager.Instance.HasTorch()) //this checks if the player is holding a torch by looking in the torch manager script
            {
                torch.gameObject.SetActive(true); //this enables the torch game object
                Destroy(oldTorch); //this destroys the torch collectable object 
                TorchManager.Instance.SetHasTorch(true); //this tells the torch manager that the player is holding a torch
            }

        }
    }

}
