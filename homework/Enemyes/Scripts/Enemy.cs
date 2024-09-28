using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private bool _canMove;

    public event Action<Enemy> EnemyBorderLeaved;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Border>())
        {
            _canMove = false;
            EnemyBorderLeaved?.Invoke(this);
        }
    }

    private void Update()
    {
        if(_canMove)
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    public void Init(Vector3 startPosition, Vector3 rotate)
    {
        transform.position = startPosition;
        transform.rotation = Quaternion.Euler(rotate);
        _canMove = true;
    }
}
