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

    public Color highlight_color;

    public float curr_angle = 0.0f;
    public float highlight_speed = 4.0f;

    public void Start()
    {
        material = gameObject.GetComponent<MeshRenderer>().material;
        rigid_body = gameObject.GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if(hovered)
        {
            material.SetColor("HighlightColor", 
                highlight_color * (((Mathf.Sin(curr_angle) + 1.0f)/2.0f) * 0.5f + 0.5f));
            
            curr_angle += Time.deltaTime * highlight_speed;
            while(curr_angle >= 2.0f*Mathf.PI) curr_angle -= 2.0f*Mathf.PI;
        }
        else
        {
            material.SetColor("HighlightColor", Color.black);
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
