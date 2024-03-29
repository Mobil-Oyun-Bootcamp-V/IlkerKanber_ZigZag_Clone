using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Pool _pool;
    Rigidbody rb;

    void Awake()
    {
        _pool = GetComponentInParent<Pool>();
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.GetComponent<Player>())
        {
            Invoke("DownCube",2f);
        }
    }
    //K�p�n d��me i�lemi
    void DownCube()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.useGravity = true;
        Invoke("SendQueue",1.5f);
    }
    //K�p� kuyru�a g�nderirken defaultlama i�lemi
    void SendQueue()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.useGravity = false;
        _pool.AddQueue(this.gameObject);
    }
}
