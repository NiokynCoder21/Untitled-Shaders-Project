using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerController playerController; //reference to the player controller

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Wall")) //if the object does have wall tag, this to ensure it is not wall running
        {
            playerController.SetGrounded(true); //this is set grounded to true meaning the player is grounded
           // playerController.SetCanAirMove(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Wall")) //if the object does have wall tag, this to ensure it is not wall running
        {
            playerController.SetGrounded(false); //this is set grounded to false meaning the player is grounded
         // playerController.SetCanAirMove(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Wall")) //if the object does have wall tag, this to ensure it is not wall running
        {
            playerController.SetGrounded(true);  //this is set grounded to true meaning the player is grounded
           // playerController.SetCanAirMove(false);
        }
    }


    //Potato Code. (2022, May 15). How to Make a Rigidbody Player Controller with Unity's Input System.[Video] Youtube. https://www.youtube.com/watch?v=1LtePgzeqjQ
}
