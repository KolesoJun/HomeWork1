using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float _speed;

    private List<Transform> _pathPoints = new List<Transform>();
    private Scaner _scaner;
    private Transform _target;
    private Animator _animator;
    private float _delayToDestoy;
    private int _damage;
    private int _indexPoint;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _scaner = GetComponentInChildren<Scaner>();
    }

    private void Start()
    {
        _delayToDestoy = 1f;
        _damage = 1;
    }

    private void Update()
    {
        Patrol();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
            player.TakeDamage(_damage);

        if (collision.gameObject.tag == "PathEnemy" && collision.transform == _target)
            _target = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Death();
    }

    private void Death()
    {
        _animator.SetTrigger("Death");
        Destroy(gameObject, _delayToDestoy);
    }

    private void Patrol()
    {
        if (_scaner.Player != null)
            transform.position = Vector3.MoveTowards(transform.position, _scaner.Player.position, _speed * Time.deltaTime);

        if (_scaner.Target != null)
        {
            Transform tempTarget = _scaner.Target;

            if (tempTarget.tag == "PathEnemy" && _pathPoints.Contains(tempTarget.transform) == false)
                _pathPoints.Add(tempTarget);
        }

        if (_target != null)
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        else
            ChangeTarget();
    }

    private void ChangeTarget()
    {
        if (_pathPoints.Count>0)
        {
            _target = _pathPoints[_indexPoint++];

            if (_indexPoint >= _pathPoints.Count)
                _indexPoint = 0;
        }
    }
}
