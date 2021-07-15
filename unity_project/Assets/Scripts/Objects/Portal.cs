using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public static List<Portal> allPortals = new List<Portal>();

    public Portal currentConnection = null;

    Camera portalCamera = null;
    Renderer panelRenderer = null;

    public bool isVisible = false; //This is set by the camera's PortalOccluder
                                    //Its a nasty hack but I dont care right now.
    
    public Renderer GetRenderer() //Just an external getter for this portal cached references 
    {
        if(panelRenderer == null) CacheReferences(); //If reference not cached, cache it
        return panelRenderer;
    }

    public void Awake()
    {
        CacheReferences();

        allPortals.Add(this);
    }

    public void OnDestroy()
    {
        allPortals.Remove(this);
    }

    public void CacheReferences()
    {
        portalCamera = transform.Find("Camera").GetComponent<Camera>();
        panelRenderer = transform.Find("Plane").GetComponent<Renderer>();
    }

    [ExecuteAlways]
    public bool ConnectTo(Portal portal)
    {
        if(!portal.isConnected() && portal != this)
        {
            currentConnection = portal;
            portal.currentConnection = this;
            return true;
        }

        return false;
    }

    [ExecuteAlways]
    public bool Disconnect()
    {
        if(currentConnection != null)
        {   
            currentConnection.currentConnection = null; //Disconects partner portal
            currentConnection = null; //Disconects this portal
            return true;
        }

        return false;
    }

    public bool isConnected()
    {

        return currentConnection != null;
    }

    public void Update()
    {
        if(isVisible) //Only do stuff to the connected's portal camera if this portal is visible
        {
            if(currentConnection != null)
            {
                Vector3 playerOffset = Camera.main.transform.position - transform.position;

                currentConnection.portalCamera.transform.localPosition = playerOffset;
            }
        }
    }  

    public void OnDrawGizmosSelected()
    {
        if(currentConnection != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, currentConnection.transform.position);
        }
    }
}
