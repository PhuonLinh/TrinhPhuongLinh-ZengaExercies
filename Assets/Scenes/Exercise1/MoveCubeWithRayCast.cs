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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) // Kiểm tra nếu chuột trái được nhấn giữ
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // Nếu raycast chạm vào đối tượng
            {
                if (hit.collider.CompareTag("Ground")) // Kiểm tra xem có chạm vào quad không
                {
                    Vector3 newPosition = hit.point;
                    newPosition.y = cube.position.y; // Giữ nguyên chiều cao của cube
                    cube.position = newPosition; // Cập nhật vị trí cube
                }
            }
        }
    }
}
