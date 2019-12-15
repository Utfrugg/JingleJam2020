using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Experimental.XR;
using Debug = UnityEngine.Debug;

public class PickupHandler : MonoBehaviour
{
    public List<Pickup> pickups = new List<Pickup>();

    void ProcessPickup(Pickup pickup)
    {
        switch (pickup.PickupType)
        {
            case Pickup.Type.Bird:
                Debug.Log("Hmm tasty bird");
                break;
            default:
                    Debug.Log("Oopsie, no behaviour established for pickup");
                break;
        }
    }

    public void AddPickup(Pickup pickup)
    {
        pickups.Add(pickup);
        pickup.SetInactive();
        pickup.enabled = false;
        ProcessPickup(pickup);
    }
}
