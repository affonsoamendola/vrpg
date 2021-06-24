using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{    
    public string pre_name;
    public string item_name;

    [TextArea]
    public string description;

    public bool hovered = false;

    public bool takeable = true;

    public Material material;
    public Rigidbody rigid_body;

    bool is_highlighted = false;

    float highlight_value = 0.0f; //0 no highlight, 1 full highlight
    float highlight_direction = -1.0f; //Direction of the smoothing of the highlight effect

    float highlight_speed = 2.0f;

    public void Start()
    {
        material = gameObject.GetComponent<MeshRenderer>().material;
        rigid_body = gameObject.GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if(hovered == true && is_highlighted == false)
        { 
            highlight_direction = 1.0f;
            is_highlighted = true;
        }

        if(hovered == false && is_highlighted == true)
        {
            highlight_direction = -1.0f;
            is_highlighted = false;
        }

        if  (
                (highlight_direction == 1.0f && //Highlight direction is a float, but this should be okay since its value is always being set by constexprs
                 highlight_value < 1.0f) 
                ||
                (highlight_direction == -1.0f &&
                highlight_value > 0.0f)
            )
        {
            highlight_value += highlight_direction * highlight_speed * Time.deltaTime;
            material.SetFloat("Highlighted", highlight_value);       
        }
    }

    public void MakeEthereal()
    {
        rigid_body.freezeRotation = true;
        rigid_body.gameObject.layer = 2;
        SetCollidersEnabled(false);
    }

    public void MakeSolid()
    {
        rigid_body.freezeRotation = false;
        rigid_body.gameObject.layer = 0;
        SetCollidersEnabled(true);
    }

    void SetCollidersEnabled(bool value)
    {
        Collider[] colliders = gameObject.GetComponents<Collider>();
    
        foreach(Collider collider in colliders)
        {
            collider.enabled = value;
        }
    }
}
