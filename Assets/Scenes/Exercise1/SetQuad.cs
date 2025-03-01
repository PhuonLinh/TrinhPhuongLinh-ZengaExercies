using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetQuad : MonoBehaviour
{
    public Color ColorQuad = new Color(0.509434f, 0.3978f, 0.3978f);
    public Vector3 SizeQuad = new Vector3(40f, 250f, 1f);
    // Start is called before the first frame update
    void Start()
    {
        Renderer quadRenderer = GetComponent<Renderer>();
        quadRenderer.material.color = ColorQuad;

        transform.localScale = SizeQuad;
    }


}
