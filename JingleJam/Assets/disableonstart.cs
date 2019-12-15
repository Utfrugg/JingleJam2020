using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableonstart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<ParticleSystem>().enableEmission = false;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
