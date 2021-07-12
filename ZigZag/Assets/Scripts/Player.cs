using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float speed;
    Mover _mover;
    LayerMask layerMask;
    bool IsFloor;
    void Start()
    {
        layerMask = LayerMask.GetMask("Floor");
        _mover = new Mover(this);
    }
    void Update()
    {
        _mover.Move(speed);

        if (Input.touchCount > 0)
        {
            Touch to = Input.GetTouch(0);

            if (to.phase == TouchPhase.Began)
            {
                if (to.position.x > Screen.width / 2)
                {
                    transform.rotation = Quaternion.Euler(0, 45, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, -45, 0);
                }
            }
        }
        Control();
    }
    void Control()
    {
        if(Physics.Raycast(transform.position,Vector3.down, 2f, layerMask))
        {
            IsFloor = true;
        }
        else 
        {
            IsFloor = false;
            Invoke("Dead", 1.5f);
        }
    }
    void Dead()
    {   
        if (!IsFloor)
        {
            Time.timeScale = 0;
            Debug.Log("Öldün dostm");
        }
    }
}