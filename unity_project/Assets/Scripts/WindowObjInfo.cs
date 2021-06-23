using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowObjInfo : Window
{
    public string pre_title = "";
    public string title = "Unknown";

    [TextArea]
    public string content = "";

    public Text pre_title_object;
    public Text title_object;
    public Text content_object;

    public GameObject target_game_object;
    public Object target_object;

    //Copies information from target to window.
    public void SetInfo(GameObject target)
    {
        target_game_object = target;
        target_object = target_game_object.GetComponent<Object>();

        pre_title = target_object.pre_name;
        title = target_object.item_name;

        content = target_object.description;

        pre_title_object.text = pre_title;
        title_object.text = title;

        content_object.text = content;
    }
}
