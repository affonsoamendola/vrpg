using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerMode
{
    PLAYER,
    MASTER
};

public class Player : MonoBehaviour
{
    public PlayerMode current_mode = PlayerMode.PLAYER;

    public MouseRaycaster raycaster;
    public Inventory inventory;

    public Transform inventory_holder;

    public bool handling_item = false;

    public Vector3 grab_position;

    public float grab_distance;

    void Start()
    {
        raycaster = Camera.main.gameObject.GetComponent<MouseRaycaster>();
        inventory = GetComponent<Inventory>();
    
        inventory_holder = transform.Find("InventoryHolder");
    }

    void Update()
    {
        if(Input.GetButtonDown("Take"))
        {
            Object object_hit = raycaster.GetHitObject(); 

            if(object_hit != null && object_hit.takeable)
            {
                inventory.Put(object_hit.gameObject);

                object_hit.transform.SetParent(inventory_holder);
                object_hit.gameObject.SetActive(false);
            }
        }

        if(Input.GetButtonDown("Grab"))
        {
            handling_item = !handling_item;

            GameObject selected_item = inventory.slots[0];

            if(handling_item)
            {
                if(selected_item != null) 
                {
                    selected_item.SetActive(true);
                    selected_item.GetComponent<Object>().MakeEthereal();
                }
            }
            else
            {
                if(selected_item != null) 
                {
                    selected_item.SetActive(false);
                    selected_item.GetComponent<Object>().MakeSolid();
                }                
            }
        }

        if(handling_item)
        {
            grab_position = (grab_distance * raycaster.GetHitNormal()) + raycaster.GetHitPosition();
            if(inventory.slots[0] != null) 
                inventory.slots[0]
                         .transform
                         .position = grab_position;
        }
    }

    void MakePlayer()
    {
        current_mode = PlayerMode.PLAYER;
    }

    void MakeMaster()
    {
        current_mode = PlayerMode.MASTER;
    }
}
