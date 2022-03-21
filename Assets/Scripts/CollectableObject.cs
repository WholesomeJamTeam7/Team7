using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectableObject : MonoBehaviour
{
    public UnityEvent onCollection;
    private void OnCollisionEnter(Collision collision)
    {
        onCollection.Invoke();
    }
}
