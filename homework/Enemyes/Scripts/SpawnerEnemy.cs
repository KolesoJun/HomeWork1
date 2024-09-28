using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private PoolEnemy _poolEnemy;
    [SerializeField] private float _delay;
    [SerializeField] private Transform[] _pointsSpawn;

    private List<Enemy> _enemiesActive = new List<Enemy>();
    private bool _isWork = true;
    private Coroutine _coroutine;

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
            Transform point = _pointsSpawn[Random.Range(0, _pointsSpawn.Length)];
            Enemy enemy = _poolEnemy.Get();

            if (enemy != null)
            {
                enemy.Init(point.localPosition, point.localEulerAngles);
                _enemiesActive.Add(enemy);
                enemy.EnemyBorderLeaved += _poolEnemy.Release;
            }

            yield return wait;
        }
    }
}
