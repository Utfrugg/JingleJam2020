using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    //public float smoothspeed = o.125f
    public Vector3 offset;

    void LateUpdate ()
    {
        transform.position = target.position + offset;
    }

}
