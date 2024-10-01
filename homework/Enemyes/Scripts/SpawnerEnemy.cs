using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PoolEnemy))]
public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private float _delay;

    private List<Enemy> _enemiesActive = new List<Enemy>();
    private bool _isWork = true;
    private Coroutine _coroutine;
    private PoolEnemy _poolEnemy;

    private void Awake()
    {
        _poolEnemy = GetComponent<PoolEnemy>();
    }

    private void OnDisable()
    {
        foreach (var enemie in _enemiesActive)
                enemie.EnemyBorderLeaved -= _poolEnemy.Release;
    }

    private void Start()
    {
        InitCoroutine();
    }

    private void InitCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (_isWork)
        {
            Enemy enemy = _poolEnemy.Get();

            if (enemy != null)
            {
                enemy.Init(transform.localPosition, _target);
                _enemiesActive.Add(enemy);
                enemy.EnemyBorderLeaved += _poolEnemy.Release;
            }

            yield return wait;
        }
    }
}
