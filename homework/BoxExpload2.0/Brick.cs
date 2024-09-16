using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Brick : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;

    private float _separateNumber = 100;
    private float _separateIndex = 2;
    private Exploder _exploder;
    private Spawner _spawner;

    private void Awake()
    {
        _exploder = GetComponentInParent<Exploder>();
        _spawner = GetComponentInParent<Spawner>();
    }

    private void OnMouseUpAsButton()
    {
        if(CanSpawn())
            _spawner.Create(transform, _radius, _force, _separateNumber);

        _exploder.Explode(transform, _radius, _force);
    }

    private bool CanSpawn()
    {
        if (Random.Range(0, _separateNumber) >= _separateNumber / _separateIndex)
            return true;

        return false;
    }

    public void SetupNewParametrs(float radius, float force, float separateNumber, Vector3 scale)
    {
        _separateNumber = separateNumber;
        transform.localScale = scale;
        _radius = radius;
        _force = force;
    }
}
