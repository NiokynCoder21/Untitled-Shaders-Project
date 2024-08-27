using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TorchCheck : MonoBehaviour
{
    public TMP_Text hasTorchText;
    public TMP_Text notTorchText;

    public bool isTouching = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTouching == false)
        {
            hasTorchText.gameObject.SetActive(false);
            notTorchText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HandTorch")) //if the object does have wall tag, this to ensure it is not wall running
        {
            hasTorchText.gameObject.SetActive(true);
            print("litten the torch");
            isTouching = true;
        }

        else if(isTouching != true)
        {
            hasTorchText.gameObject.SetActive(false);
            notTorchText.gameObject.SetActive(true);
            print("begone torch");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("HandTorch")) //if the object does have wall tag, this to ensure it is not wall running
        {
            hasTorchText.gameObject.SetActive(true);
            isTouching = true;
        }

        else if(isTouching != true)
        {
            hasTorchText.gameObject.SetActive(false);
            notTorchText.gameObject.SetActive(true);
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
        }

    }
}
