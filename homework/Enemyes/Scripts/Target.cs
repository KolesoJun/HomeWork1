using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private TargetPoint[] _points;
    [SerializeField] private float _speed;

    private int _numberPoint;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position == _points[_numberPoint].transform.position)
            _numberPoint = (_numberPoint + 1) % _points.Length;

        transform.position = Vector3.MoveTowards(transform.position, _points[_numberPoint].transform.position, _speed * Time.deltaTime);
    }
}
