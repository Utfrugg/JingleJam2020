using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MyDumbAss : MonoBehaviour
{
    public List<Color> palette = new List<Color>();
    // Start is called before the first frame update
    void Awake()
    {
        Material mat = GetComponent<SpriteRenderer>().sharedMaterial;

        mat.SetColorArray("Colours", palette);
    }
}
