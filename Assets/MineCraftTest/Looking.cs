using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looking : MonoBehaviour
{
    private readonly string AxisMouseX = "Mouse X";
    private readonly string AxisMouseY = "Mouse Y";

    [SerializeField] private float _speed;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _body;

    private void Update()
    {
        _camera.Rotate(_speed * Time.deltaTime * Vector3.right * -Input.GetAxis(AxisMouseY));
        _body.Rotate(_speed * Time.deltaTime * Vector3.up * Input.GetAxis(AxisMouseX));
    }
}
