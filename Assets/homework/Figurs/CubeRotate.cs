using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotate : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        transform.Rotate(_offset*_rotateSpeed*Time.deltaTime);
    }
}
