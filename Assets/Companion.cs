using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speedRot;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _player.position;
    }

    private void Update()
    {
        transform.position = _player.position + _offset;
        //transform.RotateAround(_player.position, Vector3.up,_speedRot);
        transform.LookAt(_target.position);
        _offset = transform.position - _player.position;
    }
}
