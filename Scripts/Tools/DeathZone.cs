using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private float _speed = 0.005f;
    private float _boost = 0.0001f;
    private float _speedMax= 0.07f;
    private float _delay = 5;
    private WaitForSeconds _wait;
    private bool _isWork = true;

    private void Start()
    {
        _wait = new WaitForSeconds(_delay);
        StartCoroutine(AssignBoost());
    }

    private void FixedUpdate()
    {
        RaisingLevel();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }

    private IEnumerator AssignBoost()
    {
        while (_isWork)
        {
            _speed += _boost;

            if (_speed >= _speedMax)
            {
                _speed = _speedMax;
                _isWork = false;
                StopCoroutine(AssignBoost());
            }

            yield return _wait;
        }
    }

    private void RaisingLevel()
    {
        transform.Translate(Vector2.up* _speed);
    }
}
