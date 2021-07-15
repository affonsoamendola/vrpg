using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalOccluder : MonoBehaviour
{
    public Camera mainCamera;

    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        Plane[] frustum = GeometryUtility.CalculateFrustumPlanes(mainCamera);

        foreach(Portal portal in Portal.allPortals)
        {
            Bounds bounds = portal.GetRenderer().bounds;

            portal.isVisible = GeometryUtility.TestPlanesAABB(frustum, bounds);
        }
    }
}
