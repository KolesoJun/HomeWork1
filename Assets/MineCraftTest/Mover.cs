using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private readonly string AxisHorizontal = "Horizontal";
    private readonly string AxisVertical = "Vertical";

    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis(AxisHorizontal), 0, Input.GetAxis(AxisVertical));
        transform.Translate(direction*_moveSpeed*Time.deltaTime);


    }
}
