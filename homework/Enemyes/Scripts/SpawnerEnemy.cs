using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private PoolEnemy _poolEnemy;
    [SerializeField] private float _delay;
    [SerializeField] private Transform[] _pointsSpawn;

    private bool _isWork = true;
    private Coroutine _coroutine;

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
        yield return new WaitForSeconds(_delay);

        while (_isWork)
        {
            Transform point = _pointsSpawn[Random.Range(0, _pointsSpawn.Length)];
            _poolEnemy.Get(point);
            yield return new WaitForSeconds(_delay);
        }
    }
}
