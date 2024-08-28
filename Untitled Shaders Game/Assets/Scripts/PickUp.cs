using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{
    public GameObject torch;
    public GameObject oldTorch;

   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HandTorch")) //if the object does have wall tag, this to ensure it is not wall running
        {
            torch.gameObject.SetActive(true);
            Destroy(oldTorch);
            TorchManager.Instance.SetHasTorch(true);
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HandTorch"))
        {
            if (!TorchManager.Instance.HasTorch())
            {
                torch.gameObject.SetActive(true);
                Destroy(oldTorch);
                TorchManager.Instance.SetHasTorch(true);
            }

        }
    }

}
