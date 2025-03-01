using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateWithMouse : MonoBehaviour
{
    public float rotationSpeed = 10f;  // Điều chỉnh tốc độ xoay
    public float minRotationY = -10f;   // Giới hạn quay trái
    public float maxRotationY = 15f;    // Giới hạn quay phải

    private bool isDragging = false;
    private float currentRotationY = 0f;
    private float lastMouseX;

    void Start()
    {
        currentRotationY = transform.eulerAngles.y; // Lấy góc quay ban đầu
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Khi nhấn chuột
        {
            isDragging = true;
            lastMouseX = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0) && isDragging) // Khi giữ chuột
        {
            float deltaX = Input.mousePosition.x - lastMouseX; // Lấy khoảng cách chuột di chuyển
            float rotationAmount = -deltaX * rotationSpeed * Time.deltaTime; // Đảo ngược hướng xoay

            // Cộng dồn vào góc quay hiện tại & giới hạn bằng Clamp
            currentRotationY = Mathf.Clamp(currentRotationY + rotationAmount, minRotationY, maxRotationY);

            // Xoay camera với góc Y đã giới hạn
            transform.rotation = Quaternion.Euler(0, currentRotationY, 0);

            lastMouseX = Input.mousePosition.x; // Cập nhật vị trí chuột cuối cùng
        }

        if (Input.GetMouseButtonUp(0)) // Khi thả chuột
        {
            isDragging = false;
        }
    }
}
