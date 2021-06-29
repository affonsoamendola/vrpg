using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WindowType
{
    OBJECT_INFO,
};

[RequireComponent(typeof(Canvas))]
public class WindowManager : MonoBehaviour
{
    public static WindowManager instance = null;
    //There should'nt be any need for multiple window managers
    //So I'm considering these a Singleton
    //The way they work right now they can easily be extended
    //to not be Singletons anymore and allow for multiple window
    //managers to exist, in case I want to make the screens of
    //other people visible, for some reason.

    public GameObject object_info_window_prefab;
    public GameObject tooltip_prefab;

    Canvas canvas;

    //Called before any Start()`s
    void Awake()
    {
        //If theres already an instance of window manager alive
        if(instance != null)
        {
            Debug.Log("Multiple Instances of Window Manager attempted, the new one was deleted");
            Destroy(this);
            return;
            //Destroy this instance
        }

        instance = this; 
        //If this is the first object of type WindowManager to be
        //created, then set instance to this object.
        //Locking the existence of more object of this type via the above if.
    }

    //Get needed references;
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    //Creates a new window
    GameObject CreateWindow(WindowType type)
    {
        if(type == WindowType.OBJECT_INFO)
        {
            GameObject go;

            go = Instantiate(object_info_window_prefab, new Vector3(0, 0, 0), Quaternion.identity);
            go.transform.SetParent(canvas.transform);

            return go;
        }

        return null;
    }

    //Opens an object window for the specificed object;
    public void OpenObjectWindow(WindowType type, GameObject object_ref)
    {
        if(type == WindowType.OBJECT_INFO)
        {
            GameObject window = CreateWindow(type);

            window.GetComponent<WindowObjInfo>()
                    .SetInfo(object_ref);

            window.GetComponent<WindowObjInfo>()
                    .MoveTo(new Vector2(0.5f, 0.5f));        
        }
    }

    //Show a tooltip
    public Tooltip ShowTooltip(string text)
    {
        GameObject tooltip_instance = GameObject.Instantiate(tooltip_prefab);

        tooltip_instance.transform.SetParent(canvas.transform);
        tooltip_instance.GetComponent<Tooltip>().text = text;

        return tooltip_instance.GetComponent<Tooltip>();
    }
}
