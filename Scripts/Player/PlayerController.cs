using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string ButtonJump = "Jump";
    private const string Money = "Money";

    [SerializeField] private float _speed;
    [SerializeField] private float _force;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _maskGround;

    public int CountMoney { get; private set; }

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _moveVector;
    private bool _isJump;
    private bool _isGround;
    private float _jumpTime;
    private float _jumpControlTime = 0.7f;
    private float _rateJump = 10;
    private float _distanceCovered;
    private float _distanceCoveredCurrent;
    private float _rotateOfScale = 1;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _isJump = Input.GetButton(ButtonJump);
        _moveVector.x = Input.GetAxis(HorizontalAxis);
        Move();
        CheckGround();
    }

    private void FixedUpdate()
    {
        Jump();
    }

    public void TakeItem(string nameItem)
    {
        switch (nameItem)
        {
            case Money:
                CountMoney++;
                break;

            default:
                break;
        }
    }

    private void Move()
    {
        _distanceCoveredCurrent = transform.position.y;

        if (_moveVector.x > 0)
        {
            _rotateOfScale = 1;
        }
        else if (_moveVector.x < 0)
        {
            _rotateOfScale = -1;
        }

        transform.localScale = new Vector2(_rotateOfScale, 1);
        _animator.SetFloat(AnimatorPlayer.Direction, Mathf.Abs(_moveVector.x));
        _rigidbody.velocity = new Vector2(_moveVector.x * _speed, _rigidbody.velocity.y);

        if (_distanceCovered <= _distanceCoveredCurrent)
            _distanceCovered = _distanceCoveredCurrent;
    }

    private void Jump()
    {
        if (_isJump && _isGround)
        {
            if((_jumpTime += Time.deltaTime )< _jumpControlTime)
            {
                _rigidbody.AddForce(Vector2.up * _force/ (_jumpTime*_rateJump));
            }
        }
        else
        {
            _jumpTime = 0;
        }
    }

    private void CheckGround()
    {
        _isGround = Physics2D.OverlapCircle(_groundCheck.position, 
            _groundCheck.GetComponent<CircleCollider2D>().radius, _maskGround);
        _animator.SetBool(AnimatorPlayer.Jump, _isGround);
    }

    public void Upgrade(ref bool isTrue)
    {
        if (isTrue)
        {
            _speed += 2;
            _force += 5;
        }
    }
}
