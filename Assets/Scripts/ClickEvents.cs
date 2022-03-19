using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ClickEvents : MonoBehaviour
{
    public UnityEvent onMouseDown;
    public UnityEvent onMouseUp;
    public UnityEvent onMouseEnter;
    public UnityEvent onMouseExit;
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
        onMouseEnter.Invoke();
    }
    private void OnMouseExit()
    {
        onMouseExit.Invoke();
    }
}
