using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class Pickup : MonoBehaviour
{
    public enum Type
    {
        Default,
        Bird,
        Respawn,
        Tree
    };

    public Type PickupType = Type.Default;

    public void SetInactive()
    {
        GetComponentInParent<BoxCollider2D>().enabled = false;
        GetComponentInParent<SpriteRenderer>().enabled = false;
    }
}
