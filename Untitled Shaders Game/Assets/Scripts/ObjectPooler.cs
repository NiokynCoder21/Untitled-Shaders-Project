using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag; //what different objects in the pool go as, e.g enemy tag and bullet tag
        public GameObject prefab; //the object that will be spawned
        public int size; //the number of objects that will be spawned 
    }

    #region Singleton
    public static ObjectPooler Instance; //this allows it to be called anywhere in code using objectpooler.instance

    private void Awake()
    {
        Instance = this; //this to make sure the instance always points to this object pooler
    }

    #endregion

    public List<Pool> pools; //this will store all the pools , they can be assigned in the inspector
    public Dictionary<string, Queue<GameObject>> poolDictionary; //this is used to store and manage the pools of objects 

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>(); //this creates a new dictionary 

        foreach (Pool pool in pools) //this loops over the collection pool objects 
        {
            Queue<GameObject> objectPool = new Queue<GameObject>(); //for each new pool a new queue gameobject is created

            for (int i = 0; i < pool.size; i++) //determines how many objects should be created for the pool
            {
                GameObject obj = Instantiate(pool.prefab); //this creates the game object
                obj.SetActive(false); //this sets the game object to false
                objectPool.Enqueue(obj); //this stores the new object into the pool 
            }

            poolDictionary.Add(pool.tag, objectPool); //after all the objects have created the pool is added to the dictionarry
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation) //a function that can be called in other scripts
    {
        if (!poolDictionary.ContainsKey(tag)) //checks whehter the pool has an object with the tag , if no it prints to console
        {
            print("Pool with tag" + tag + "doesnt exist");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue(); // if an object with the tag is in the pool it gets and removes the first object from the pool

        objectToSpawn.SetActive(true); //this enables the game object
        objectToSpawn.transform.position = position; //this places the object at the desired position, if none is set it spawns at 0,0,0
        objectToSpawn.transform.rotation = rotation; //this ensures the object faces the correct direction when spawned

        poolDictionary[tag].Enqueue(objectToSpawn); //after the object has been spawned and used it is imeddiately put back into the queue

        return objectToSpawn; //retruns the spawned object 
    }

    //Brakeys. (2018, February 11). OBJECT POOLING in Unity[Video]. Youtube. https://www.youtube.com/watch?v=tdSmKaJvCoA
}
