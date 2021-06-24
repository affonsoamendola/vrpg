using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float run_multiplier = 5.0f;
    public Vector3 speed = new Vector3(1.0f, 1.0f, 1.0f);

    bool no_clip = false;

    Rigidbody rigid_body;
    CapsuleCollider capsule_collider;

    MouseLook mouse_look;

    void Start()
    {   
        //Get needed references
        rigid_body = GetComponent<Rigidbody>();
        capsule_collider = GetComponent<CapsuleCollider>();
    
        mouse_look = MouseLook.instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 offset = new Vector3(0.0f, 0.0f, 0.0f);
    
        if(no_clip == true)
        {
            //Disable Gravity and collisison
            rigid_body.useGravity = false;
            capsule_collider.enabled = false;

            float run_result = Input.GetButton("Run") ? run_multiplier : 1.0f;
        
            offset.x = Input.GetAxis("Horizontal") * speed.x * run_result * Time.fixedDeltaTime;
            offset.z = Input.GetAxis("Vertical") * speed.z * run_result * Time.fixedDeltaTime;

            offset.y += (Input.GetButton("Up") ? 1.0f : 0.0f) * speed.y * Time.fixedDeltaTime;
            offset.y += (Input.GetButton("Down") ? 1.0f : 0.0f) * (-speed.y) * Time.fixedDeltaTime;
            //Calculate how much to move

            offset = Quaternion.Euler(mouse_look.current_euler.x, mouse_look.current_euler.y, 0.0f) * offset;
            //Rotate movement according to look angle

            transform.Translate(offset);
            //Do the move (No-clip, so no need to go through rigidBody)
        }
        else
        {
            //Enable gravity and collisions
            rigid_body.useGravity = true;
            capsule_collider.enabled = true;

            float run_result = Input.GetButton("Run") ? run_multiplier : 1.0f;
        
            offset.x = Input.GetAxis("Horizontal") * speed.x * run_result * Time.fixedDeltaTime;
            offset.z = Input.GetAxis("Vertical") * speed.z * run_result * Time.fixedDeltaTime;
            //Calculate how much to move (Only need two directions)

            offset = Quaternion.Euler(0.0f, mouse_look.current_euler.y, 0.0f) * offset;
            //Rotate according to view

            rigid_body.MovePosition(transform.position + offset);   
            //Do the move (Through rigidBody so we get collisions (I think?))
        }
    }
}