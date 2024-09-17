using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Spawner))]
[RequireComponent(typeof(Exploder))]
public class BricksController : MonoBehaviour
{
    [SerializeField] private List<Brick> _bricks;

    private Spawner _spawner;
    private Exploder _exploder;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
        _exploder = GetComponent<Exploder>();
    }

    private void OnEnable()
    {
        foreach (var brick in _bricks)
            brick.Select += Distribute;
    }

    private void OnDisable()
    {
        foreach (var brick in _bricks)
            brick.Select -= Distribute;
    }

    private void Distribute(Transform brickTransform, bool canSeparate)
    {
        Brick brick = brickTransform.GetComponent<Brick>();
        _exploder.ExplodeForRadius(brick.transform, brick.Radius, brick.Force);

        if (canSeparate)
        {
            List<Rigidbody> objectsSpaw = _spawner.Create(brick.transform, brick.Radius, brick.Force, brick.SeparateNumber);
            AddNewObjects(objectsSpaw);
            brick.ExplodeSpawnObjects(objectsSpaw);
        }

        _bricks.Remove(brick);
    }

    private void AddNewObjects(List<Rigidbody> objectsSpaw)
    {
        foreach (var item in objectsSpaw)
            _bricks.Add(item.GetComponent<Brick>());
    }
}
