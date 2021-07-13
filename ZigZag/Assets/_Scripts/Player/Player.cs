using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    public int Point { get; set; }
    public bool IsDead { get; set; }

    Mover _mover;
    LayerMask layerMask;
    bool IsFloor, IsRight, IsLeft;
    float time;

    void Start()
    {
        IsRight = true;
        IsLeft = false;
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
                Debug.Log("Bastý");
                if (IsRight)
                {
                    transform.rotation = Quaternion.Euler(0, -45, 0);
                    IsLeft = true;
                    IsRight = false;
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 45, 0);
                    IsRight = true;
                    IsLeft = false;
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
            IsDead = true;
            Debug.Log("Öldün dostm");
        }
    }
}
