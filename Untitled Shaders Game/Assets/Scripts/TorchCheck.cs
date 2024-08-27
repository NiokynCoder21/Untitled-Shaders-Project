using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TorchCheck : MonoBehaviour //this is on the sphere and checks what hits it
{
    public TMP_Text hasTorchText;
    public TMP_Text notTorchText;

    public PlayerController controller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HandTorch"))
        {
            if (TorchManager.Instance.HasTorch())
            {
                hasTorchText.gameObject.SetActive(true);
                notTorchText.gameObject.SetActive(false);
                controller.SetTorch(true);
            }
        }

        else if(!TorchManager.Instance.HasTorch())
        {
            hasTorchText.gameObject.SetActive(false);
            notTorchText.gameObject.SetActive(true);
            print("begone torch2");
            controller.SetTorch(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("HandTorch"))
        {
            if (TorchManager.Instance.HasTorch())
            {
                hasTorchText.gameObject.SetActive(true);
                notTorchText.gameObject.SetActive(false); // Hide the other text
                controller.SetTorch(true);
            }
        }
        else if(!TorchManager.Instance.HasTorch())
        {
            hasTorchText.gameObject.SetActive(false);
            notTorchText.gameObject.SetActive(true);
            controller.SetTorch(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("HandTorch"))
        {
            if (TorchManager.Instance.HasTorch())
            {
                hasTorchText.gameObject.SetActive(false);
                notTorchText.gameObject.SetActive(false); // Make sure both texts are hidden
                print("end it now");
                controller.SetTorch(false);
            }
        }

        else if(!TorchManager.Instance.HasTorch())
        {
            hasTorchText.gameObject.SetActive(false);
            notTorchText.gameObject.SetActive(false); // Hide both texts
            print("end it now2");
        }
    }
}
