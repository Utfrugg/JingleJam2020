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
                GetComponentInParent<Player>().GetChonk(1);
                break;
            case Pickup.Type.Respawn:
                Debug.Log("Fucked up");
                GetComponentInParent<PlayerDeath>().SetRespawn(pickup.GetComponent<Transform>().position);
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
