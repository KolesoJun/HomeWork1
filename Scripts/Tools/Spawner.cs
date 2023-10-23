using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private GameObject _pointSpawn;
    [SerializeField] private float _delay;

    private WaitForSeconds _corutineDelay;
    private bool _isWorking = true;
    private Vector2 _direction = Vector2.right;
    private float _rotate = -1;

    private void Start()
    {
        _corutineDelay = new WaitForSeconds(_delay);
        StartCoroutine(CreatureObjects());
    }

    public void MoveHorizontal(float range)
    {
        transform.Translate(_direction * _speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) >= Mathf.Abs(range))
        {
            _direction *= _rotate;
        }
    }

    private IEnumerator CreatureObjects()
    {
        while (_isWorking)
        {
            Instantiate(ChoseSpawnPrefab(), _pointSpawn.transform.position, Quaternion.identity);
            yield return _corutineDelay;
        }
    }

    private GameObject ChoseSpawnPrefab()
    {
        return _prefabs[Random.Range(0, _prefabs.Length)];
    }
}
