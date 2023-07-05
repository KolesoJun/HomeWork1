using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _timePause;
    [SerializeField] private Enemy _enemy;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        foreach (Transform point in _points)
        {
            Instantiate(_enemy, point.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_timePause);
        }
    }
}
