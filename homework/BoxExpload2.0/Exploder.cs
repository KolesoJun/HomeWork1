using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Exploder : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;
    [SerializeField] private ParticleSystem _effect;

    private Spawner _spawner;

    private void Start()
    {
        _spawner = GetComponentInParent<Spawner>();
    }

    private void OnMouseUpAsButton()
    {
        Explode();
    }

    private void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _radius);

        foreach (var hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                float forceCurrent = Mathf.MoveTowards(_force, 0, hits.Length);
                hit.attachedRigidbody.AddForce((hit.transform.position - transform.position) * forceCurrent, ForceMode.Impulse);
            }
        }

        _spawner.CreatePrefabs(transform, _radius, _force);
        Instantiate(_effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void SetupNewParametrs(float radius, float force)
    {
        transform.localScale /= 2;
        _radius = radius;
        _force = force;
    }
}
