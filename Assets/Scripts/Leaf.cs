using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip pickupClip, dropClip;
    private bool dragging;
    void OnMouseDown()
    {
        dragging = true;
        source.PlayOneShot(pickupClip);
    }

}
