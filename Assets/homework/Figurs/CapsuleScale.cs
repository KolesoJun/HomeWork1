using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleScale : MonoBehaviour
{
    [SerializeField, Range(1, 10)] private float _speedScale;
    [SerializeField] private Vector3 _scaleTarget;

    private Vector3 _scaleDefault;

    private void Start()
    {
        _scaleDefault = transform.localScale;
    }

    private void Update()
    {
        if (transform.localScale != _scaleTarget)
            transform.localScale = Vector3.MoveTowards(transform.localScale, _scaleTarget, _speedScale * Time.deltaTime);
        else
            transform.localScale = _scaleDefault;
    }
}
