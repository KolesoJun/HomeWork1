using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class Pooler : MonoBehaviour
{
    [SerializeField] private Brick _prefab;
    [SerializeField] private int _countObjects = 10;

    private List<Brick> _bricksPool;
    private Stack<Brick> _bricksPoolActive;
    private Spawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
        Init();
    }

    public Brick Get()
    {
        if (_bricksPoolActive.Count > 0)
        {
            Brick brick = _bricksPoolActive.Pop();
            brick.gameObject.SetActive(true);
            brick.Init(this);
            return brick;
        }

        return null;
    }

    public void Release(Brick brick)
    {
        brick.gameObject.SetActive(false);
        _bricksPoolActive.Push(brick);
    }

    private Brick Create()
    {
        Brick brick = Instantiate(_prefab, _spawner.transform);
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
