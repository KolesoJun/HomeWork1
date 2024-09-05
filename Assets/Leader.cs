using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour
{
    [SerializeField] private Transform[] _waitPoints;
    [SerializeField, Range(0,10)] private float _speed;

    private int _currentPointIndex;

    private void Update()
    {
        if (transform.position == _waitPoints[_currentPointIndex].position)
        {
            _currentPointIndex = (_currentPointIndex + 1) % _waitPoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _waitPoints[_currentPointIndex].position, _speed * Time.deltaTime);
        transform.LookAt(_waitPoints[_currentPointIndex].position);
    }
}
