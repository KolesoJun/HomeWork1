using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [SerializeField] private Brick _prefab;
    [SerializeField] private int _countObjects = 10;

    private List<Brick> _bricksPool;

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
        Brick brick = _bricksPool.FirstOrDefault(obj => obj.isActiveAndEnabled == false);

        if (brick == null)
            Create();

        brick.gameObject.SetActive(true);
        brick.Init();
        return brick;
    }

    private void Release(Brick brick)
    {
        brick.gameObject.SetActive(false);
    }

    private void Create()
    {
        Brick brick = Instantiate(_prefab, transform);
        brick.gameObject.SetActive(false);
        _bricksPool.Add(brick);
    }

    private void Init()
    {
        _bricksPool = new List<Brick>();

        for (int i = 0; i < _countObjects; i++)
            Create();
    }
}
