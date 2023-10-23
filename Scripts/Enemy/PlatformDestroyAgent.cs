using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformDestroyAgent : MonoBehaviour
{
    private Platform _platform;
    private Vector3 _direction;
    private CircleCollider2D _circle;

    private void Start()
    {
        _circle = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<PlayerController>())
        {
            print("poluchy");
        }

        if (collision.TryGetComponent<Platform>(out Platform platform))
        {
            _platform = platform;
            _circle.isTrigger = false;
            StartCoroutine(Move());
        }
    }

    private IEnumerator Move()
    {
        float timeDestroy = 3;
        float delay = 0.3f;
        yield return new WaitForSeconds(delay);
        _direction = _platform.transform.position;
        transform.DOMove(_direction, timeDestroy);
        yield return new WaitForSeconds(timeDestroy);
        _platform.Destroy();
        _platform = null;
        _circle.isTrigger = true;
        StopCoroutine(Move());
    }
}
