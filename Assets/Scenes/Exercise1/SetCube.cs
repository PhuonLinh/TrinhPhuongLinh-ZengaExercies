using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCube : MonoBehaviour
{
    private Renderer cubeRenderer;
    public Color cubeColor = Color.yellow;
    // Start is called before the first frame update
    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        cubeRenderer.material.color = cubeColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
