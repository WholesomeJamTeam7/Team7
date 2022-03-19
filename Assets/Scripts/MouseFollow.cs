using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    public bool isClickDrag;
    public bool useObjectZ;
    bool hovered;
    bool selected;
    float z;
    public float customZ = 10f;

    private void Awake()
    {
        z = transform.position.z;
    }
    private void OnMouseOver()
    {
        hovered = true;
    }
    private void OnMouseExit()
    {
        hovered = false;
    }
    private void OnMouseDown()
    {
        if (!isClickDrag)
        {
            if (selected)
            {
                selected = false;
            }
            else
            {
                selected = true;
            }
        }
        else
        {
            selected = true;
        }
    }
    private void OnMouseUp()
    {
        if (isClickDrag)
        {
            selected = false;
        }
    }
    private void Update()
    {
        Vector3 temp = Input.mousePosition;
        if (!useObjectZ)
        {
            temp.z = customZ;
        }
        else
        {
            temp.z = z + transform.localScale.z*2;
        }
        if (selected)
        {
            this.transform.position = Camera.main.ScreenToWorldPoint(temp);
        }
    }
}
