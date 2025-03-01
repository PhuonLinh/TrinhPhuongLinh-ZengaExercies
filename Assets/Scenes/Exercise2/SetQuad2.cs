using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetQuad2 : MonoBehaviour
{
    public Color ColorQuad = Color.green;
    
    void Start()
    {
        Renderer quadRenderer = GetComponent<Renderer>();
        quadRenderer.material.color = ColorQuad;

    }
}
