using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeWithRayCast : MonoBehaviour
{
    public Camera cam;
    public Transform cube;
    public Color cubeColor = Color.yellow;

    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) 
            {
                if (hit.collider.CompareTag("Ground")) 
                {
                    Vector3 newPosition = hit.point;
                    newPosition.y = cube.position.y; 
                    cube.position = newPosition; 
                }
            }
        }
    }
}
