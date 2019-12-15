using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerDeath : MonoBehaviour
{

    public Transform respawnPoint;

    public void Respawn()
    {
        gameObject.transform.position = respawnPoint.position;
    }
}
