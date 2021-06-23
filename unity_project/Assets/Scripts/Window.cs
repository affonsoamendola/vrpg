using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour
{
    public void MoveTo(Vector2 position) //Moves window around screen
    {
        RectTransform rect = GetComponent<RectTransform>();

        Vector2 converted_position;

        converted_position.x = position.x * Screen.width;
        converted_position.y = position.y * Screen.height;

        rect.anchoredPosition = converted_position;
    }

    public void SignalClose()
    {
        Destroy(gameObject);
    }
}

