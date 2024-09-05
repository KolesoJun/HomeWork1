using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEst : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speedMove;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _target.position;
    }

    private void Update()
    {
        //способ перемещения через вектор3
        //transform.position = Vector3.MoveTowards(transform.position, _target.position, _speedMove * Time.deltaTime);

        //линейная интерполяция - не достигнет точки (гипербола)
        transform.position = Vector3.Lerp(transform.position, _target.position, _speedMove);

        // способ перемещения через Translate
        //var direction = (_target.position - transform.position).normalized;
        //transform.Translate(direction * _speedMove, Space.World);

        //поворот вокруг оси y
        //transform.Rotate(0, 180, 0);

        //поворот в сторону вектора
        //transform.LookAt(direction);

        //поворот со смещением
        //transform.position = _target.position + _offset;
        //transform.RotateAround(_target.position, Vector3.up, _speedMove * Time.deltaTime);
        //transform.Rotate(Vector3.up * _speedMove * Time.deltaTime);
        //_offset = transform.position - _target.position;
        
        // поворот через кватернион
        //transform.rotation *= Quaternion.Euler(0, 10, 0);

        //поворот вокруг заданной оси
        //transform.RotateAround(transform.position, _target.position, 5);
    }

}
