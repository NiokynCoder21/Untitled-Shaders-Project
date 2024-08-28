using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSpawner : MonoBehaviour
{
    public List<Vector3> spawnPositions;
    private bool hasSpawned = false;

    private void FixedUpdate()
    {
        if (hasSpawned == false)
        {
            SpawnAllObjects();
        }
    }

    void SpawnAllObjects()
    {
        foreach (Vector3 position in spawnPositions)
        {
            ObjectPooler.Instance.SpawnFromPool("HandTorch", position, Quaternion.identity);
            hasSpawned = true;
        }
    }

}
