using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private float _distanceCamera;

    private Vector3 _position;

    private void Awake()
    {
        if (_player == null)
            _player = GameObject.FindObjectOfType<PlayerController>();

        if (_distanceCamera > 0)
            _distanceCamera *= -1;
    }

    void Update()
    {
        _position = _player.transform.position;
        _position.z = _distanceCamera;
        transform.position = Vector3.Lerp(transform.position, _position, Time.deltaTime);
    }
}
