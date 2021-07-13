using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject GoldPrefab;
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
    //Küpü alma iþlemi
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
    //Küpü yerleþtirme iþlemi
    void SetXUp() 
    {
        currentLocation = new Vector3(currentLocation.x + 0.7071068f, currentLocation.y, currentLocation.z + 0.7071068f);
        CreateGold();
    }
    void SetXDown() 
    {
        currentLocation = new Vector3(currentLocation.x- 0.7071068f, currentLocation.y, currentLocation.z + 0.7071068f);
        CreateGold();
    }
    //Ekranda gold çýkarma iþlemi
    void CreateGold()
    {
        //%20 ihtimal
        int range = Random.Range(0, 5);
        if (range == 0)
        {
            Vector3 poz = new Vector3(currentLocation.x, currentLocation.y + 2, currentLocation.z);
            Instantiate(GoldPrefab, poz, transform.rotation);
        }
        
    }
}
