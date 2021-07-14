using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorState
{
    HIDDEN,
    SHOWN_CLOSED,
    SHOWN_OPEN
}

public class MagicDoor : MonoBehaviour
{
    public DoorState current_state = DoorState.HIDDEN;
    public DoorState target_state = DoorState.HIDDEN;

    public GameObject door_go;

    public float current_timer = 0.0f;

    public float portal_open_time = 10.0f; //In seconds
    public float door_appear_time = 10.0f;

    public float door_open_time = 10.0f;
    public float door_closed_y;

    public float portal_size;

    public AudioSource ping_sound;

    bool animating = false;

    public delegate void AnimateDel();

    AnimateDel Animate;

    public void Appear()
    {
        target_state = DoorState.SHOWN_CLOSED;
    }

    public void Start()
    {
        portal_size = gameObject.transform.localScale.x;
        
        door_go = transform.GetChild(0).gameObject;
        door_closed_y = door_go.transform.localPosition.y;

        ping_sound = GetComponent<AudioSource>();

        if(current_state == DoorState.HIDDEN)
        {
            Vector3 new_scale;

            new_scale = gameObject.transform.localScale;

            new_scale.x = 0.0f;
                
            gameObject.transform.localScale = new_scale;
        }

        if(current_state == DoorState.SHOWN_OPEN)
        {
            door_go.transform.localPosition = new Vector3(0f, 0f, 0f);
        }
    }

    public void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            target_state = DoorState.SHOWN_CLOSED;
        }

        if(animating == false)
        {
            if(current_state == DoorState.HIDDEN && 
                target_state == DoorState.SHOWN_CLOSED)
            {
                Animate = AnimateAppear;
                animating = true;
            }
        }

        if(animating)
        {
            Animate();
        }
    }

    public void AnimateAppear()
    {
        Vector3 new_scale;

        new_scale = gameObject.transform.localScale;

        new_scale.x = Mathf.Lerp( 0.0f, 
                                  portal_size, 
                                  current_timer/portal_open_time);

        gameObject.transform.localScale = new_scale;

        current_timer += Time.deltaTime;

        if(current_timer >= portal_open_time)
        {
            new_scale.x = portal_size;

            gameObject.transform.localScale = new_scale;
            current_timer = 0.0f;

            Animate = AnimateDoorRise;
        }
    }

    public void AnimateDoorRise()
    {
        Vector3 new_position = door_go.transform.localPosition;

        new_position.y = Mathf.Lerp( door_closed_y,
                                     0.0f, 
                                     current_timer/door_appear_time);

        door_go.transform.localPosition = new_position;

        current_timer += Time.deltaTime;

        if(current_timer >= door_appear_time)
        {
            ping_sound.Play();

            new_position.y = 0.0f;

            door_go.transform.localPosition = new_position;

            current_state = DoorState.SHOWN_CLOSED;
            current_timer = 0.0f;

            animating = false;
        }
    }
}
