using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TorchCheck : MonoBehaviour
{
    public TMP_Text hasTorchText;
    public TMP_Text notTorchText;

    public bool isTouching = false; //checks the text
    public PlayerController controller;
   
    // Update is called once per frame
    void Update()
    {
        if(isTouching == false)
        {
            hasTorchText.gameObject.SetActive(false);
            notTorchText.gameObject.SetActive(false);
            controller.SetTorch(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HandTorch")) //if the object does have wall tag, this to ensure it is not wall running
        {
            hasTorchText.gameObject.SetActive(true);
            print("litten the torch");
            isTouching = true;
            controller.SetTorch(true);
        }

        else if(isTouching != true)
        {
            hasTorchText.gameObject.SetActive(false);
            notTorchText.gameObject.SetActive(true);
            print("begone torch");
            controller.SetTorch(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("HandTorch")) //if the object does have wall tag, this to ensure it is not wall running
        {
            hasTorchText.gameObject.SetActive(true);
            isTouching = true;
            controller.SetTorch(true);
        }

        else if(isTouching != true)
        {
            hasTorchText.gameObject.SetActive(false);
            notTorchText.gameObject.SetActive(true);
            controller.SetTorch(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("HandTorch")) //if the object does have wall tag, this to ensure it is not wall running
        {
            hasTorchText.gameObject.SetActive(false);
            notTorchText.gameObject.SetActive(false);
            print("end it now");
            isTouching = false;
            controller.SetTorch(false);
        }

    }
}
