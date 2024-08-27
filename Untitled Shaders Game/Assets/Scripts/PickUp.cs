using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject torch;
    public GameObject oldTorch;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NoTorch")) //if the object does have wall tag, this to ensure it is not wall running
        {
            torch.gameObject.SetActive(true);
            Destroy(oldTorch);
        }
    }

}
