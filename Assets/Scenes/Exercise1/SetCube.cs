using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCube : MonoBehaviour
{
    private Renderer cubeRenderer;
    public Color cubeColor = Color.yellow;
   
    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        cubeRenderer.material.color = cubeColor;
    }


    void Update()
    {
        
    }
}
