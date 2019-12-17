using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbDeathAnimationScript : MonoBehaviour
{
    Transform trans;
    float launchSpeed = 10;
    public Transform thingwithbounds;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        launchSpeed = Mathf.Clamp(launchSpeed - 3.6f * Time.deltaTime, 0, 10);
   
        Vector3 transvec = new Vector3(1 - launchSpeed/10, launchSpeed, 0) * Time.deltaTime;
        trans.position += transvec;

        if (trans.position.x > 15)
            trans.position -= new Vector3(thingwithbounds.GetComponent<SpriteRenderer>().bounds.size.x, 0);
    }
}
