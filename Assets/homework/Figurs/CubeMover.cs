using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    private readonly string AxisHorizontal = "Horizontal";

    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotate;
    [SerializeField, Range(1, 10)] private float _speedScale;
    [SerializeField] private Vector3 _scaleTarget;

    private Vector3 _scaleDefault;

    private void Start()
    {
        _scaleDefault = transform.localScale;
    }

    private void Update()
    {
        Move();
        Rotate(Input.GetAxis(AxisHorizontal));
        ChangeScale();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * _speedMove * Time.deltaTime);
    }

    private void Rotate(float direction)
    {
        transform.Rotate(Vector3.up * direction * _speedRotate * Time.deltaTime);
    }

    private void ChangeScale()
    {
        if (transform.localScale != _scaleTarget)
            transform.localScale = Vector3.MoveTowards(transform.localScale, _scaleTarget, _speedScale * Time.deltaTime);
        else
            transform.localScale = _scaleDefault;
    }
}
