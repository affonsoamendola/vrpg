using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float run_multiplier = 5.0f;
    public Vector3 speed = new Vector3(1.0f, 1.0f, 1.0f);
    public Vector2 mouse_sensibility = new Vector2(100.0f, 100.0f);

    public Vector3 last_mouse_position;

    public bool no_clip = false;

    public Rigidbody rigid_body;
    public CapsuleCollider capsule_collider;

    public MouseLook mouse_look;

    public bool grounded = false;

    void Start()
    {
        last_mouse_position = Input.mousePosition;

        rigid_body = GetComponent<Rigidbody>();
        capsule_collider = GetComponent<CapsuleCollider>();
    
        mouse_look = Camera.main.gameObject.GetComponent<MouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(0.0f, 0.0f, 0.0f);
    
        if(no_clip == true)
        {
            rigid_body.useGravity = false;
            capsule_collider.enabled = false;

            float run_result = Input.GetButton("Run") ? run_multiplier : 1.0f;
        
            offset.x = Input.GetAxis("Horizontal") * speed.x * run_result * Time.deltaTime;
            offset.z = Input.GetAxis("Vertical") * speed.z * run_result * Time.deltaTime;

            offset.y += (Input.GetButton("Up") ? 1.0f : 0.0f) * speed.y * Time.deltaTime;
            offset.y += (Input.GetButton("Down") ? 1.0f : 0.0f) * (-speed.y) * Time.deltaTime;

            offset = Quaternion.Euler(mouse_look.current_euler_x, mouse_look.current_euler_y, 0.0f) * offset;

            transform.Translate(offset);
        }
        else
        {
            rigid_body.useGravity = !grounded; // If not grounded, enable gravity.

            capsule_collider.enabled = true;

            float run_result = Input.GetButton("Run") ? run_multiplier : 1.0f;
        
            offset.x = Input.GetAxis("Horizontal") * speed.x * run_result * Time.deltaTime;
            offset.z = Input.GetAxis("Vertical") * speed.z * run_result * Time.deltaTime;
            
            offset = Quaternion.Euler(0.0f, mouse_look.current_euler_y, 0.0f) * offset;

            rigid_body.MovePosition(transform.position + offset);
        }
        
    }

    void OnCollisionStay(Collision collision)
    {
        grounded = false;

        if(Vector3.Angle(collision.relativeVelocity, Vector3.up) <= 35)
        {
            grounded = true;
        }
    }
}