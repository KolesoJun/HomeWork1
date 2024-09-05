using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string AxisHorizontal = "Horizontal";
    private const string AxisVertical = "Vertical";

    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotate;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float direction = Input.GetAxis(AxisVertical);
        float distance = direction * Time.deltaTime * _speedMove;
        transform.Translate(Vector3.forward * distance);
    }

    private void Rotate()
    {
        float rotate = Input.GetAxis(AxisHorizontal);
        transform.Rotate(Vector3.up* rotate*_speedRotate* Time.deltaTime);
    }
}
