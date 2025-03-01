using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaeQuadWithRaycast : MonoBehaviour
{
    public Camera cam;
    public Transform quad;

    private Vector3 lastMouseWorldPos;
    private bool isDragging = false;
    public float rotationSpeed = 30f; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (GetMouseWorldPosition(out lastMouseWorldPos)) 
            {
                isDragging = true;
            }
        }

        if (Input.GetMouseButton(0) && isDragging) 
        {
            Vector3 currentMouseWorldPos;
            if (GetMouseWorldPosition(out currentMouseWorldPos))
            {
                Vector3 fromCenterToLast = lastMouseWorldPos - quad.position;
                Vector3 fromCenterToCurrent = currentMouseWorldPos - quad.position;

                float angle = Vector3.SignedAngle(fromCenterToLast, fromCenterToCurrent, Vector3.forward);

                quad.transform.Rotate(Vector3.forward, angle * rotationSpeed, Space.World);

                lastMouseWorldPos = currentMouseWorldPos; 
            }
        }

        if (Input.GetMouseButtonUp(0)) 
        {
            isDragging = false;
        }
    }

    bool GetMouseWorldPosition(out Vector3 worldPosition)
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.transform == quad)
            {
                worldPosition = hit.point;
                return true;
            }
        }

        worldPosition = Vector3.zero;
        return false;
    }

}
