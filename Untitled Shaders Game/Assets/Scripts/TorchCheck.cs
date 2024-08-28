using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TorchCheck : MonoBehaviour //this is on the sphere and checks what hits it
{
    public TMP_Text hasTorchText; //this is the text that tells the player how to light their torch
    public TMP_Text notTorchText; //this is the tect that tells the player they have no torch

    public PlayerController controller; //this a reference to the player controller script

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HandTorch")) ////if collide with game object check if it has tag hand torch
        {
            if (TorchManager.Instance.HasTorch()) //this checks if the player is holding a torch by looking in the torch manager script
            {
                hasTorchText.gameObject.SetActive(true); //this enables the game object
                notTorchText.gameObject.SetActive(false); //this disables the game object
                controller.SetTorch(true); //this tells the torch manager script that the player is holding a torch
            }
        }

        else if(!TorchManager.Instance.HasTorch()) //this checks if the player is not holding a torch by looking in the torch manager script
        {
            hasTorchText.gameObject.SetActive(false); //this disables the game object
            notTorchText.gameObject.SetActive(true); //this enables the game object
            controller.SetTorch(false); //this tells the torch manager script that the player is not holding a torch
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("HandTorch")) //if collide with game object check if it has tag hand torch
        {
            if (TorchManager.Instance.HasTorch()) //this checks if the player is holding a torch by looking in the torch manager script
            {
                hasTorchText.gameObject.SetActive(true); //this enables the game object
                notTorchText.gameObject.SetActive(false); //this disables the game object
                controller.SetTorch(true); //this tells the torch manager script that the player is holding a torch
            }
        }
        else if(!TorchManager.Instance.HasTorch()) //this checks if the player is not holding a torch by looking in the torch manager script
        {
            hasTorchText.gameObject.SetActive(false); //this disables the game object
            notTorchText.gameObject.SetActive(true); //this enables the game object
            controller.SetTorch(false); //this tells the torch manager script that the player is not holding a torch
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("HandTorch")) //if collide with game object check if it has tag hand torch
        {
            if (TorchManager.Instance.HasTorch()) //this checks if the player is holding a torch by looking in the torch manager script
            {
                hasTorchText.gameObject.SetActive(false); //this disables the game object
                notTorchText.gameObject.SetActive(false); // Make sure both texts are hidden
                controller.SetTorch(false); //this tells the torch manager script that the player is not holding a torch
            }
        }

        else if(!TorchManager.Instance.HasTorch()) //this checks if the player is not holding a torch by looking in the torch manager script
        {
            hasTorchText.gameObject.SetActive(false); //this disables the game object
            notTorchText.gameObject.SetActive(false); //this disables the game object
        }
    }
}
