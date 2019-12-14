using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Experimental.XR;
using Debug = UnityEngine.Debug;

public class PickupHandler : MonoBehaviour
{
    public List<Pickup> pickups = new List<Pickup>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

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

        ;

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Pickup newPickup)) {
            pickups.Add(newPickup);
            newPickup.SetInactive();
            newPickup.enabled = false;
            ProcessPickup(newPickup);
        }
    }
}
