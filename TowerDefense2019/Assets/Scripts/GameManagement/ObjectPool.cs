using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    
    [System.Serializable]
    public class Pool
    {
        public GameObject PoolPrefab;
        [SerializeField] public string PoolTag = "Grunt";
        public int PoolSize;
    }

    public Dictionary<string, Queue<GameObject>> PoolDictionary;
    public List<Pool> Pools;
    private navAgent agent;
    #region SingeltonInAwake
    public static ObjectPool Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion


    private void Start()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();


        foreach(Pool pool in Pools)
        {
            Queue<GameObject> queuePool = new Queue<GameObject>();

            for (int i = 0; i < pool.PoolSize ; i++)
            {
                GameObject poolObject = Instantiate(pool.PoolPrefab);
                poolObject.SetActive(false);
                queuePool.Enqueue(poolObject);
            }

            PoolDictionary.Add(pool.PoolTag, queuePool);
            Debug.Log("poolTag -> " + pool.PoolTag + " added");
        }
        //Debug.Log("All Pools are instansiated" + PoolDictionary.Count + " " + PoolDictionary.Keys.ToString() );
    }

    public GameObject SpawnFromPool (string poolTag, Vector3 position, Quaternion rotation)
    {

        if (!PoolDictionary.ContainsKey(poolTag))
        {

            Debug.Log("ObjectPool dose not have the Pooltag in the dictionary ->" + poolTag);
            return null;
        }
        GameObject objectToSpawn = PoolDictionary[poolTag].Dequeue();
        

        
       
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.SetActive(true);
        Debug.Log("ObjectPool.cs -> spawnFromPool");

        return objectToSpawn;
    }

    public void EnQueueInPool(string poolTag, GameObject poolThis)
    {

        if (!PoolDictionary.ContainsKey(poolTag))
        {

            Debug.Log("ObjectPool dose not have the Pooltag in the dictionary ->" + poolTag);
            return;
        }
        Debug.Log("Pooled ->" + poolTag);

        PoolDictionary[poolTag].Enqueue(poolThis);
        poolThis.SetActive(false);

        Debug.Log("Pooled ->" + poolTag);

    }

}
