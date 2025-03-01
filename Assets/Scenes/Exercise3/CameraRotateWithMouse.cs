using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateWithMouse : MonoBehaviour
{
    public float rotationSpeed = 10f;  
    public float minRotationY = -10f;   
    public float maxRotationY = 15f;    

    private bool isDragging = false;
    private float currentRotationY = 0f;
    private float lastMouseX;

    void Start()
    {
        currentRotationY = transform.eulerAngles.y; 
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            isDragging = true;
            lastMouseX = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0) && isDragging) 
        {
            float deltaX = Input.mousePosition.x - lastMouseX; 
            float rotationAmount = -deltaX * rotationSpeed * Time.deltaTime;
            
            currentRotationY = Mathf.Clamp(currentRotationY + rotationAmount, minRotationY, maxRotationY);

            transform.rotation = Quaternion.Euler(0, currentRotationY, 0);

            lastMouseX = Input.mousePosition.x; 
        }

        if (Input.GetMouseButtonUp(0)) 
        {
            isDragging = false;
        }
    }
}
