using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pooler))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnSectorMin;
    [SerializeField] private Vector3 _spawnSectorMax;
    [SerializeField] private float _delay;

    private Pooler _pooler;
    private bool _canWork = true;

    private void Awake()
    {
        _pooler = GetComponent<Pooler>();
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (_canWork)
        {
            Brick brick = _pooler.Get();

            if (brick != null)
            {
                brick.transform.position = new Vector3(Random.Range(_spawnSectorMin.x, _spawnSectorMax.x),
                    Random.Range(_spawnSectorMin.y, _spawnSectorMax.y), Random.Range(_spawnSectorMin.z, _spawnSectorMax.z));
            }
                      
            yield return wait;
        }
    }

    private void sbor()
    {

    }
}
