using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchManager : MonoBehaviour
{
    public static TorchManager Instance;

    private bool hasTorch = true;

    private void Awake()
    {
        // Ensure there is only one instance of the TorchManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Persist through scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to set the player's torch status
    public void SetHasTorch(bool value)
    {
        hasTorch = value;
    }

    // Method to check if the player has a torch
    public bool HasTorch()
    {
        return hasTorch;
    }
}
