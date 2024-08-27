using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    public GameObject torchPrefab;  // Torch prefab
    public int poolSize = 10;       // Size of the pool

    private Queue<GameObject> torchPool;  // Pool of torches

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        torchPool = new Queue<GameObject>();

        // Initialize pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject torch = Instantiate(torchPrefab);
            torch.SetActive(false);
            torchPool.Enqueue(torch);
        }
    }

    // Function to retrieve a torch from the pool
    public GameObject GetTorchFromPool()
    {
        if (torchPool.Count > 0)
        {
            GameObject torch = torchPool.Dequeue();
            torch.SetActive(true);
            return torch;
        }
        else
        {
            // If pool is empty, instantiate a new torch
            GameObject torch = Instantiate(torchPrefab);
            return torch;
        }
    }

    // Function to return a torch back to the pool
    public void ReturnTorchToPool(GameObject torch)
    {
        torch.SetActive(false);
        torchPool.Enqueue(torch);
    }
}
