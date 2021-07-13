using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyObject", 20);    
    }
    Player _player;
    void OnTriggerEnter(Collider obj)
    {
        _player = obj.GetComponent<Player>();
        if (_player)
        {   
            _player.Point++;
            Debug.Log(_player.Point);
            Destroy(this.gameObject);
        }
    }
    void DestroyObject() 
    {
        Destroy(this.gameObject);
    }
}
