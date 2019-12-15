using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("AAAAAAAAAAAA");
        collider.gameObject.GetComponent<PlayerDeath>()?.Respawn();
    }
}
