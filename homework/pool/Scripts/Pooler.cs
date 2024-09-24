using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [SerializeField] private Brick _prefab;
    [SerializeField] private int _countObjects = 10;

    private List<Brick> _bricksPool;
    private Stack<Brick> _bricksPoolActive;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        foreach (var brick in _bricksPool)
            brick.Death += Release;
    }

    private void OnDisable()
    {
        foreach (var brick in _bricksPool)
            brick.Death -= Release;
    }

    public Brick Get()
    {
        Brick brick = _bricksPoolActive.Pop();

        if (brick == null)
            Create();

        brick.gameObject.SetActive(true);
        return brick;
    }

    private void Release(Brick brick)
    {
        brick.Init();
        brick.gameObject.SetActive(false);
        _bricksPoolActive.Push(brick);
    }

    private void Create()
    {
        Brick brick = Instantiate(_prefab, transform);
        brick.gameObject.SetActive(false);
        _bricksPool.Add(brick);
        _bricksPoolActive.Push(brick);
    }

    private void Init()
    {
        _bricksPoolActive = new Stack<Brick>();
        _bricksPool = new List<Brick>();

        for (int i = 0; i < _countObjects; i++)
            Create();
    }
}
