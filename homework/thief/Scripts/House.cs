using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class House : MonoBehaviour
{
    public event Action EnteredThief;
    public event Action OutThief;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
            EnteredThief?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
            OutThief?.Invoke();
    }
}
