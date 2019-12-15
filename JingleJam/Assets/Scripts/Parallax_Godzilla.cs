using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_Godzilla : MonoBehaviour
{
    private float length, startposG;
    public GameObject camG;
    public float parallaxEffectG;

    // Start is called before the first frame update
    void Start()
    {
        startposG = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = (camG.transform.position.x * parallaxEffectG);

        transform.position = new Vector3(startposG + dist, transform.position.y, transform.position.z);

    }
}
