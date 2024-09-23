using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Pooler))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private float _delay;

    private bool _canWork = true;
    private Pooler _pooler;

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
            brick.transform.position = _spawnPositions[Random.Range(0, _spawnPositions.Length)].position;
            yield return wait;
        }
    }
}
