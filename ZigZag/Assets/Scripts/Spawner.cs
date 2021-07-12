using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform startLocation;
    [SerializeField] int StartSpawnCount;
    [SerializeField] float CreateTime;
    Vector3 currentLocation;
    int select;
    Pool _pool;

    void Awake()
    {
        _pool= GameObject.Find("ObjectPool").GetComponent<Pool>();
       
        currentLocation = new Vector3(startLocation.transform.position.x,
            startLocation.transform.position.y, startLocation.transform.position.z);
        
    }
    void Start()
    {
        Setup();
        InvokeRepeating("TakeCube", 0, CreateTime);
    }
    void Setup()
    {
        for(int i = 1; i <= StartSpawnCount; i++)
        {
            TakeCube();
        }
    }
    void TakeCube()
    {
        select=Random.Range(0, 2);

        if (select == 0)
        {
            if (currentLocation.x <= -3.5f)
            {
                SetXUp();
            }
            else
            {
                SetXDown();
            }
        }
        else  
        { 
            if (currentLocation.x >= 2f)
            {
                SetXDown();
            }
            else
            {
                SetXUp();
            }
        }
        GameObject go =_pool.getObject();
        
        go.SetActive(true);
        go.transform.position = currentLocation;
    }
    void SetXUp() 
    {
        currentLocation = new Vector3(currentLocation.x + 0.7071068f, currentLocation.y, currentLocation.z+0.7071068f);
    }
    void SetXDown() 
    {
        currentLocation = new Vector3(currentLocation.x- 0.7071068f, currentLocation.y, currentLocation.z + 0.7071068f);
    }
}
