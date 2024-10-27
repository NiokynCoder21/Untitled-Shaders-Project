using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TorchManager : MonoBehaviour
{
    public static TorchManager Instance;

    private bool hasTorch = true; //a bool to keep track of whether not the player is holding the torch
    public TMP_Text oneTorchText; //this is the one torch text
    public TMP_Text noTorchText; //this is the two torch text

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(hasTorch == true) //if the player is holding a torch
        {
            oneTorchText.gameObject.SetActive(true); //show they have 1 torch
            noTorchText.gameObject.SetActive(false); //show they have 0 torch
        }

        else
        {
            oneTorchText.gameObject.SetActive(false); //show they have 1 torch
            noTorchText.gameObject.SetActive(true); //show they have 0 torch
        }
    }

    public void SetHasTorch(bool value) //this is a method to set wheher the player is holding the torth or not
    {
        hasTorch = value;
    }

    public bool HasTorch() //this is a method to check whether the player is holding the torth or not
    {
        return hasTorch;
    }
}
