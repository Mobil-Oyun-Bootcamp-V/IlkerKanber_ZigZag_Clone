using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] GameObject spawnObject;
    [SerializeField] int spawnCount;
    public Queue<GameObject> poolQueue; 
    
    void Awake()
    {
        poolQueue = new Queue<GameObject>();
    }
    void Start()
    {
        Spawn(spawnCount);   
    }
    void Spawn(int count)
    {
        for (int i = 1; i <= count; i++)
        {
          GameObject obj = Instantiate(spawnObject, transform);
          obj.SetActive(false);
          poolQueue.Enqueue(obj);
        }
    }
    public void AddQueue(GameObject cube)
    {
        cube.SetActive(false);
        poolQueue.Enqueue(cube);
    }
    public GameObject getObject()
    {
        Debug.Log(poolQueue.Count);
        if (poolQueue.Count == 0)
        {
            Spawn(10);
        }
        return poolQueue.Dequeue();
    }
}
