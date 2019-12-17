using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Collider2D))]
public class PlayerDeath : MonoBehaviour
{
    public float deathY;
    public float endingY;

    public Vector3 respawnPoint;
    Transform trans;

    public void Start()
    {
        trans = GetComponent<Transform>();
        respawnPoint = trans.position;
    }

    public void Update()
    {
        if (trans.position.y < deathY)
        {
            Respawn();
        }

        if (trans.position.y > endingY)
        {
            SceneManager.LoadScene("ChonkDeath");
        }
    }

    public void SetRespawn(Vector3 newPos)
    {
        respawnPoint = newPos;
    }

    public void Respawn()
    {
        gameObject.transform.position = respawnPoint;
    }
}
