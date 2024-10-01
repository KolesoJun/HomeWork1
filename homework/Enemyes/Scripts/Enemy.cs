using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Target _target;

    public event Action<Enemy> EnemyBorderLeaved;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>())
        {
            EnemyBorderLeaved?.Invoke(this);
        }
    }

    private void Update()
    {
        if (_target != null)
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed* Time.deltaTime);
    }

    public void Init(Vector3 startPosition, Target target)
    {
        transform.position = startPosition;
        _target = target;
    }
}
