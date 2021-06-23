using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WindowType
{
    OBJECT_INFO,
};

public class WindowManager : MonoBehaviour
{
    public GameObject object_info_window_prefab;
    public GameObject tooltip_prefab;

    public Canvas canvas;

    void Start()
    {
        canvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();
    }

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

    public void OpenWindow(WindowType type, GameObject object_ref)
    {
        if(type == WindowType.OBJECT_INFO)
        {
            GameObject window = CreateWindow(type);//.GetComponent<WindowObj>().SetObjID(obj_id);
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
