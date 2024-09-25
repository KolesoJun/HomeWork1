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
            brick.LeavingBorder += Release;
    }

    private void OnDisable()
    {
        foreach (var brick in _bricksPool)
            brick.LeavingBorder -= Release;
    }

    public Brick Get()
    {
        if (_bricksPoolActive.Count > 0)
        {
            Brick brick = _bricksPoolActive.Pop();
            brick.gameObject.SetActive(true);
            brick.Init();
            return brick;
        }
        else
        {
           return Create();
        }
    }

    private void Release(Brick brick)
    {
        brick.gameObject.SetActive(false);
        _bricksPoolActive.Push(brick);
    }

    private Brick Create()
    {
        Brick brick = Instantiate(_prefab, transform);
        brick.gameObject.SetActive(false);
        _bricksPool.Add(brick);
        _bricksPoolActive.Push(brick);
        return brick;
    }

    private void Init()
    {
        _bricksPoolActive = new Stack<Brick>();
        _bricksPool = new List<Brick>();

        for (int i = 0; i < _countObjects; i++)
            Create();
    }
}
