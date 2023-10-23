using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private ScanerEnemy _scaner;
    private Animator _animator;

    private void Awake()
    {
        _scaner = GetComponentInChildren<ScanerEnemy>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    { 
        Patrol();
    }

    private void Patrol()
    {
        if (_scaner.IsObstacle || _scaner.CanRotate)
        {
            Rotate();
        }

        float speedAnimation = 1;
        _animator.SetFloat(AnimatorEnemy.Walk, speedAnimation);
        transform.Translate( new Vector2(Time.deltaTime * _speed, 0));
    }

    private void Rotate()
    {
        float tempRotateY = transform.rotation.y;
        float angleRotate = 180f;

        if (tempRotateY.Equals(angleRotate))
        {
            tempRotateY = 0;
        }
        else
        {
            tempRotateY = angleRotate;
        }

        transform.Rotate(0, tempRotateY, 0);
    }
}
