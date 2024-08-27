using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TorchCheck : MonoBehaviour //this is on the sphere and checks what hits it
{
    public TMP_Text hasTorchText;
    public TMP_Text notTorchText;

    public bool isTouching = false; //checks the text
    public PlayerController controller;
    public bool haveTorch = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HandTorch"))
        {
            hasTorchText.gameObject.SetActive(true);
            notTorchText.gameObject.SetActive(false); 
            print("litten the torch");
            isTouching = true;
            haveTorch = true;
            controller.SetTorch(true);
        }
        else if (other.gameObject.CompareTag("NoTorch"))
        {
            hasTorchText.gameObject.SetActive(false);
            notTorchText.gameObject.SetActive(true);
            print("begone torch2");
            isTouching = false;
            haveTorch = false;
            controller.SetTorch(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("HandTorch") && !isTouching)
        {
            hasTorchText.gameObject.SetActive(true);
            notTorchText.gameObject.SetActive(false); // Hide the other text
            isTouching = true;
            haveTorch = true;
            controller.SetTorch(true);
        }
        else if (other.gameObject.CompareTag("NoTorch") && isTouching)
        {
            hasTorchText.gameObject.SetActive(false);
            notTorchText.gameObject.SetActive(true);
            isTouching = false;
            haveTorch = false;
            controller.SetTorch(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("HandTorch"))
        {
            hasTorchText.gameObject.SetActive(false);
            notTorchText.gameObject.SetActive(false); // Make sure both texts are hidden
            print("end it now");
            isTouching = false;
            haveTorch = false;
            controller.SetTorch(false);
        }
        else if (other.gameObject.CompareTag("NoTorch"))
        {
            hasTorchText.gameObject.SetActive(false);
            notTorchText.gameObject.SetActive(false); // Hide both texts
            print("end it now2");
            isTouching = false;
        }
    }
}
