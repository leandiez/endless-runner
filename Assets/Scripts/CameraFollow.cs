using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 locationOffset = new Vector3(6.0f, 4.0f, 0.0f);
    //public Vector3 rotationOffset = new Vector3(20, -90, 0); 

    void FixedUpdate()
    {
        transform.position = target.position + locationOffset;
    }
}
