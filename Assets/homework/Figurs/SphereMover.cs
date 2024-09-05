using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMover : MonoBehaviour
{
    [SerializeField] private Transform[] _point;
    [SerializeField] private float _speed;

    private int _indexPoint = 0;

    private void Update()
    {
        if (transform.position == _point[_indexPoint].position)
            _indexPoint = (_indexPoint + 1) % _point.Length;

        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _point[_indexPoint].position, _speed * Time.deltaTime);
    }
}
