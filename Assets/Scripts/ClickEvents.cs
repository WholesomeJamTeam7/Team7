using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ClickEvents : MonoBehaviour
{
    public bool scaleSpriteOnHover;
    public GameObject spriteToScale;
    public float scaleMultiplier;
    public UnityEvent onMouseDown;
    public UnityEvent onMouseUp;
    public UnityEvent onMouseEnter;
    public UnityEvent onMouseExit;
    Vector3 origScale;
    private void Start()
    {
        if (scaleSpriteOnHover)
        {
            origScale = spriteToScale.transform.localScale;
        }
    }
    private void OnMouseDown()
    {
        onMouseDown.Invoke();
    }
    private void OnMouseUp()
    {
        onMouseUp.Invoke();
    }
    private void OnMouseEnter()
    {
        if (scaleSpriteOnHover)
        {
            spriteToScale.transform.localScale = new Vector3(spriteToScale.transform.localScale.x + scaleMultiplier, spriteToScale.transform.localScale.y + scaleMultiplier, spriteToScale.transform.localScale.z + scaleMultiplier);
        }
        onMouseEnter.Invoke();
    }
    private void OnMouseExit()
    {
        if (scaleSpriteOnHover)
        {
            spriteToScale.transform.localScale = origScale;
        }
        onMouseExit.Invoke();
    }
}
