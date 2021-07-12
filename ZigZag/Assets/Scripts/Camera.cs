using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    [SerializeField] float targetDistance;
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, targetObject.transform.position.z - targetDistance);
    }
}
