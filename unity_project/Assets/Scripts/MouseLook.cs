using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float current_euler_x;
    public float current_euler_y;

    public Vector2 mouse_sensibility = new Vector2(100.0f, 100.0f);

    public Vector3 last_mouse_position;
    // Update is called once per frame
    void Update()
    {
        Vector3 delta_mouse = Input.mousePosition - last_mouse_position;
        last_mouse_position = Input.mousePosition;

        if(Input.GetMouseButton(1))
        {
            current_euler_y += (delta_mouse.x * 1000.0f / Screen.width) * mouse_sensibility.x * Time.deltaTime;
            current_euler_x -= (delta_mouse.y * 1000.0f / Screen.height) * mouse_sensibility.y * Time.deltaTime;
            current_euler_x = Mathf.Clamp(current_euler_x, -85.0f, 85.0f);
        }

        Quaternion rotation = Quaternion.Euler(current_euler_x, current_euler_y, 0.0f);
        
        transform.rotation = rotation;
    }
}
