using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public string text = "";

    public Text text_component;

    public RectTransform tooltip_rect_transform;

    public float offset_x = 25;
    public float offset_y = -20;

    public void Start()
    {
        text_component = transform.Find("Text").GetComponent<Text>();
        tooltip_rect_transform = GetComponent<RectTransform>();
    }

    public void Update()
    {
        text_component.text = text;

        Vector2 position;

        position.x = Input.mousePosition.x + offset_x;
        position.y = Input.mousePosition.y + offset_y;

        tooltip_rect_transform.anchoredPosition = position; 
    }
}
