using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class Pickup : MonoBehaviour
{
    public enum Type
    { Default, Bird
    };

    public Type PickupType = Type.Default;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetInactive()
    {
        GetComponentInParent<BoxCollider2D>().enabled = false;
        GetComponentInParent<SpriteRenderer>().enabled = false;
    }
}
