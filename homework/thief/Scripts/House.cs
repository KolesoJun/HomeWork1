using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class House : MonoBehaviour
{
    private bool _isInside;

    public event Action<bool> LoggedThief;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
        {
            _isInside = true;
            LoggedThief?.Invoke(_isInside);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
        {
            _isInside = false;
            LoggedThief?.Invoke(_isInside);
        }
    }
}
