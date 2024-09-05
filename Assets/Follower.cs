using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField, Range(0, 10)] private float _speed;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position, _speed * Time.deltaTime);
    }
}
