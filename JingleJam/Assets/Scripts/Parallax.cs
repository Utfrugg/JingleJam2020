using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos, startposy;
    public GameObject cam;
    public float parallaxEffect;
    public float parallaxEffectY;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        startposy = transform.localPosition.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        float disty = (cam.transform.position.y * parallaxEffectY);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Min(startposy,startposy - disty),transform.localPosition.z);
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
