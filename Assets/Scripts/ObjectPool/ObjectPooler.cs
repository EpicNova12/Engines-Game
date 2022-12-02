using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    //Create single instance of the pooler
    public static ObjectPooler instance;

    //Create a list that will contain all our object pools
    public List<Pool> pools;

    //Then create a queue for the objects in the pool
    Queue<GameObject> objectPool;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        //Loop through each pool
        foreach(Pool pool in pools)
        {
            //Create a new Queue of objects for that pool
            objectPool = new Queue<GameObject>();

            //Another loop with going through the size of the pool itself
            for(int i = 0;i<pool.size;i++)
            {
                GameObject obj = Instantiate(pool.projectile);   //Create a new gameobject snf instantiate it
                obj.SetActive(false); //Set it to false since we dont need it yet
                objectPool.Enqueue(obj); 
            }

            //Add the pool to the dicionary of pools with the pool of objects we made and the tag we want
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    //Our funtion to actually get our object from the pool
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        //Basic debugging tool to tell us when their is no tag
        if(!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("There is no "+ tag +" pool");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue(); //Create a new game object and take it from the object up next in the queue

        objectToSpawn.SetActive(true); //Turn it on
        //Input the transforms of where we want it
        objectToSpawn.transform.position = position; 
        objectToSpawn.transform.rotation = rotation;
        
        poolDictionary[tag].Enqueue(objectToSpawn); //Add it back to the queue

        return objectToSpawn; //Spawn it
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
