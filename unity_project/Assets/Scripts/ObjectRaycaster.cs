using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ObjectRaycaster : MonoBehaviour
{
    bool disabled = false;
    public bool has_hit = false;
    
    public Object hit_object = null;
    public Vector3 hit_normal = Vector3.zero;
    public Vector3 hit_position = Vector3.zero;

    Camera cam;
    WindowManager window_manager;

    Tooltip shown_tooltip = null;
    Object tooltip_target_object = null;

    void Start()
    {
        //Getting the references to the components needed.
        cam = gameObject.GetComponent<Camera>();
    
        window_manager = GameObject.FindWithTag("WindowManager")
                                   .GetComponent<WindowManager>();
    }

    // Update is called once per frame
    void Update()
    {
        has_hit = false;

        //Resets last object's hovered condition
        if(hit_object != null && hit_object.hovered) 
            hit_object.hovered = false;

        //Master Off Switch
        if(!disabled)
        {   
            hit_object = FireRay();

            if(hit_object != null)
            {
                has_hit = true;
            }

            if( hit_object != null && 
                !hit_object.hovered) 
            {
                hit_object.hovered = true;
            }
            //Make object understand that it is hovering.

            if( hit_object != null && 
                hit_object.hovered &&
                shown_tooltip == null)
            {
                shown_tooltip = window_manager.ShowTooltip(hit_object.item_name);
                tooltip_target_object = hit_object;
            }

            if( shown_tooltip != null &&
                (hit_object == null || hit_object != tooltip_target_object ))
            {
                GameObject.Destroy(shown_tooltip.gameObject);

                shown_tooltip = null;
                tooltip_target_object = null;
            }

            //On Click
            if( hit_object != null && 
                hit_object.hovered &&
                Input.GetMouseButtonDown(0))
            {
                window_manager.OpenWindow(WindowType.OBJECT_INFO, hit_object.gameObject);
            }
        }
    }

    Object FireRay()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //Create ray to fire

        hit_object = null;
        hit_normal = Vector3.zero;

        //Fire ray, put data in hit
        if(Physics.Raycast(ray, out hit, 100))
        {        
            hit_object = hit.transform.gameObject.GetComponent<Object>();

            hit_normal = hit.normal;
            hit_position = hit.point;

            if(hit_object != null)
            {//If hit something relevant
                hit_object = hit.transform.gameObject.GetComponent<Object>();
                //Pull object info
                
            }
        }

        return hit_object;
    }

    public Object GetHitObject()
    {
        if(has_hit)
        {
            return hit_object;
        }

        return null;
    }

    public Vector3 GetHitNormal()
    {
        return hit_normal;
    }

    public Vector3 GetHitPosition()
    {
        return hit_position;
    }
}
