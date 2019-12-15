using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Experimental.XR;
using Debug = UnityEngine.Debug;

public class PickupHandler : MonoBehaviour
{
    public Transform maxChonkText;
    public ParticleSystem puke;
    public Transform deadbird;
    public List<Pickup> pickups = new List<Pickup>();

    void ProcessPickup(Pickup pickup)
    {
        switch (pickup.PickupType)
        {
            case Pickup.Type.Bird:
                Debug.Log("Hmm tasty bird");
                GetComponentInParent<Player>().GetChonk(1);
                pickup.SetInactive();
                pickup.enabled = false;
                if (GetComponentInParent<Player>().Chonk >= 4)
                {
                    maxChonkText.GetComponent<SpriteRenderer>().enabled = true;
                    maxChonkText.GetComponent<TextFlash>().enabled = true;
                }
                break;
            case Pickup.Type.Respawn:
                Debug.Log("Fucked up");
                GetComponentInParent<PlayerDeath>().SetRespawn(pickup.GetComponent<Transform>().position);
                pickup.SetInactive();
                pickup.enabled = false;
                break;
            case Pickup.Type.Tree:
                Debug.Log("Deliver");
                for (int i = 0; i < GetComponentInParent<Player>().Chonk; i++)
                {
                    Instantiate(deadbird, gameObject.transform.Find("cat_head").gameObject.transform.position, Quaternion.identity);
  
                }
                if (GetComponentInParent<Player>().Chonk > 0)
                {
                     puke.enableEmission = true;
                     puke.Play();
                }
                   
                GetComponentInParent<Player>().Chonk = 0;
                GetComponentInParent<Player>().GetChonk(0);
                break;
            default:
                    Debug.Log("Oopsie, no behaviour established for pickup");
                break;
        }
    }

    public void AddPickup(Pickup pickup)
    {
        pickups.Add(pickup);
        ProcessPickup(pickup);
    }
}
