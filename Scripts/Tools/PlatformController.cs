using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private Platform[] _prefabsCube;
    [SerializeField] private GameObject _prefabsMoney;
    [SerializeField] private GameObject[] _prefabsSpawnOnCubeEnemy;

    private int _countCube;
    private int _sizePlatform;
    private int _sizePlatformMin = 3;
    private int _sizePlatformMax = 10;
    private float _sizeWhitespace;
    private float _sizeWhitespaceMin = 0.25f;
    private float _sizeWhitespaceMax = 0.5f;
    private float _stepX = 0.25f;
    private float _stepOnSpawnUp = 0.2f;
    private float _delaySpawn = 0.5f;
    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_delaySpawn);
    }

    public IEnumerator Build()
    {
        GenerateSequence();
        _sizeWhitespace = Random.Range(_sizeWhitespaceMin, _sizeWhitespaceMax);
        Shift(_sizeWhitespace);
        yield return _wait;
    }

    private void GenerateSequence()
    {
        _sizePlatform = Random.Range(_sizePlatformMin, _sizePlatformMax);

        for (int i = 0; i < _sizePlatform; i++)
        {
            GameObject prefab;
            prefab = _prefabsCube[Random.Range(0, _prefabsCube.Length)].gameObject;
            Instantiate(prefab, transform.position, Quaternion.identity);
            _countCube++;
            Vector2 position = new Vector2(transform.position.x, transform.position.y + _stepOnSpawnUp);
            Shift(_stepX);
        }
    }

    private void Shift(float x)
    {
        Vector2 positionNew = transform.position;
        transform.position = new Vector2(positionNew.x + x, positionNew.y);
    }
}
