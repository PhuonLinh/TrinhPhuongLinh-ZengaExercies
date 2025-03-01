using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaeQuadWithRaycast : MonoBehaviour
{
    public Camera cam;
    public Transform quad;

    private Vector3 lastMouseWorldPos;
    private bool isDragging = false;
    public float rotationSpeed = 30f; // Tăng tốc độ xoay

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Khi nhấn chuột
        {
            if (GetMouseWorldPosition(out lastMouseWorldPos)) // Lấy vị trí chuột trên Quad bằng Raycast
            {
                isDragging = true;
            }
        }

        if (Input.GetMouseButton(0) && isDragging) // Khi giữ chuột
        {
            Vector3 currentMouseWorldPos;
            if (GetMouseWorldPosition(out currentMouseWorldPos))
            {
                // Vector từ tâm Quad đến vị trí chuột trước & sau
                Vector3 fromCenterToLast = lastMouseWorldPos - quad.position;
                Vector3 fromCenterToCurrent = currentMouseWorldPos - quad.position;

                // Tính góc giữa 2 vector
                float angle = Vector3.SignedAngle(fromCenterToLast, fromCenterToCurrent, Vector3.forward);

                // Xoay theo hướng chuột, loại bỏ Time.deltaTime để nhanh hơn
                quad.transform.Rotate(Vector3.forward, angle * rotationSpeed, Space.World);

                lastMouseWorldPos = currentMouseWorldPos; // Cập nhật vị trí chuột cuối cùng
            }
        }

        if (Input.GetMouseButtonUp(0)) // Khi thả chuột
        {
            isDragging = false;
        }
    }

    // Hàm Raycast để lấy vị trí chuột trên Quad
    bool GetMouseWorldPosition(out Vector3 worldPosition)
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.transform == quad) // Nếu chuột chạm vào Quad
            {
                worldPosition = hit.point;
                return true;
            }
        }

        worldPosition = Vector3.zero;
        return false;
    }

}
