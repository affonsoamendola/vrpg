using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextShadow : MonoBehaviour
{
    public float char_size = 25.8307f;

    public Text text;

    public RectTransform rect_transform;

    void Start()
    {
        rect_transform = gameObject.GetComponent<RectTransform>();
    }

    void Update()
    {
        rect_transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, char_size * text.text.Length);
    }
}
