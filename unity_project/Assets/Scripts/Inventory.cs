using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> slots = new List<GameObject>();

    public void Put(GameObject go)
    {
        slots.Add(go);
    }

    public void Remove(GameObject go)
    {
        slots.Remove(go);
    }
}
