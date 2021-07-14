using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal current_connection = null;

    Camera portal_camera = null;
    Renderer panel_renderer = null;

    public Renderer getRenderer()
    {
        if(panel_renderer == null) CacheReferences();
        return panel_renderer;
    }

    public void Awake()
    {
        CacheReferences();
    }

    public void CacheReferences()
    {
        portal_camera = transform.Find("Camera").GetComponent<Camera>();
        panel_renderer = transform.Find("Plane").GetComponent<Renderer>();
    }

    [ExecuteAlways]
    public bool ConnectTo(Portal portal)
    {
        if(!portal.isConnected() && portal != this)
        {
            current_connection = portal;
            portal.current_connection = this;
            return true;
        }

        return false;
    }

    [ExecuteAlways]
    public bool Disconnect()
    {
        if(current_connection != null)
        {   
            current_connection.current_connection = null; //Disconects partner portal
            current_connection = null; //Disconects this portal
            return true;
        }

        return false;
    }

    public bool isConnected()
    {

        return current_connection != null;
    }

    public void Update()
    {
        if(panel_renderer.isVisible)
        {
            if(current_connection != null)
            {
                Vector3 player_offset = Camera.main.transform.position - transform.position;

                current_connection.portal_camera.transform.position = current_connection.transform.position + player_offset;
            }
        }
    }  

    public void OnDrawGizmosSelected()
    {
        if(current_connection != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, current_connection.transform.position);
        }
    }
}
