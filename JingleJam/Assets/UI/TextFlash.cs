using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFlash : MonoBehaviour
{
    SpriteRenderer render;
    public float FlashTime;
    public float TimeElapsed;
    // Update is called once per frame


    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        TimeElapsed += Time.deltaTime;
        if (TimeElapsed > FlashTime) {
            TimeElapsed = 0;
            render.enabled = !render.enabled;
        }
    }
}
