using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private Enemy _enemy;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        foreach (Transform point in _points)
        {
            float timePause = 2;
            Instantiate(_enemy, point.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timePause);
        }
    }
}
