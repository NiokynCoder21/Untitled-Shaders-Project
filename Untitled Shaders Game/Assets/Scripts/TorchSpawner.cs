using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSpawner : MonoBehaviour
{
    public List<Vector3> spawnPositions; //this is a list to keep all the spawn locations 
    private bool hasSpawned = false; //has the objects spawned 

    private void FixedUpdate()
    {
        if (hasSpawned == false)  //if the objects have not spawned yet
        {
            SpawnAllObjects(); //method that spawns all the objects
        }
    }

    void SpawnAllObjects()
    {
        foreach (Vector3 position in spawnPositions) //this loops through the vector 3 position of all the spawn positions
        {
            ObjectPooler.Instance.SpawnFromPool("HandTorch", position, Quaternion.identity);
            hasSpawned = true;
        }
    }

}
