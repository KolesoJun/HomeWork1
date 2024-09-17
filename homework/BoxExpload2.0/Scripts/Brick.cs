using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Brick : MonoBehaviour
{
    public event UnityAction<Transform, bool> Select;

    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private float _radius;
    [SerializeField] private float _force;

    private float _separateNumber = 100;
    private float _separateIndex = 2;

    public float Radius => _radius;
    public float Force => _force;
    public float SeparateNumber => _separateNumber;

    private void OnMouseUpAsButton()
    {
        Select?.Invoke(transform, CanSpawn());
        Instantiate(_effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Init(float radius, float force, float separateNumber, Vector3 scale)
    {
        _separateNumber = separateNumber;
        transform.localScale = scale;
        _radius = radius;
        _force = force;
    }

    public void ExplodeSpawnObjects(List<Rigidbody> spawnObjects)
    {
        foreach (var spawnObject in spawnObjects)
            spawnObject.AddForce(Vector3.up * _force, ForceMode.Impulse);
    }

    private bool CanSpawn()
    {
        return (Random.Range(0, _separateNumber) >= _separateNumber / _separateIndex);
    }
}
