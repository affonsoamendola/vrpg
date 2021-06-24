using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public static MouseLook instance = null;

    public Vector2 current_euler;
    public Vector2 mouse_sensibility = new Vector2(100.0f, 100.0f);

    public Vector3 last_mouse_position;

    //Called before any Start()`s
    void Awake()
    {
        //If theres already an instance \alive
        if(instance != null)
        {
            Debug.Log("Multiple Instances of Mouse Look attempted, the new one was deleted");
            Destroy(this);
            //Destroy this instance
        }

        instance = this; 
        //If this is the first object to be
        //created, then set instance to this object.
        //Locking the existence of more object of this type via the above if.
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta_mouse = Input.mousePosition - last_mouse_position;
        last_mouse_position = Input.mousePosition;

        if(Input.GetMouseButton(1))
        {
            current_euler.y += (delta_mouse.x * 1000.0f / Screen.width) * mouse_sensibility.x * Time.deltaTime;
            current_euler.x -= (delta_mouse.y * 1000.0f / Screen.height) * mouse_sensibility.y * Time.deltaTime;
            current_euler.x = Mathf.Clamp(current_euler.x, -85.0f, 85.0f);
        }

        Quaternion rotation = Quaternion.Euler(current_euler.x, current_euler.y, 0.0f);
        
        transform.rotation = rotation;
    }
}
