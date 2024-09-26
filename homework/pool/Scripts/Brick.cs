using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BrickColorManager))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Brick : MonoBehaviour
{
    private bool _isFirstEnter;
    private MeshRenderer _meshRenderer;
    private BrickColorManager _colorManager;
    private Pooler _pooler;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _colorManager = GetComponent<BrickColorManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isFirstEnter == false)
        {
            if (collision.gameObject.TryGetComponent<BorderPlane>(out _))
            {
                _isFirstEnter = true;
                _meshRenderer.material.color = _colorManager.ChangeColor();
                StartCoroutine(CountdownLife());
            }
        }
    }

    public void Init(Pooler pooler)
    {
        _pooler = pooler;
        _meshRenderer.material.color = Color.white;
        _isFirstEnter = false;
    }

    private IEnumerator CountdownLife()
    {
        float lifeTimeMin = 2f;
        float lifeTimeMax = 5f;
        float erorRandom = 1f;
        yield return new WaitForSeconds(Random.Range(lifeTimeMin, lifeTimeMax + erorRandom));
        _pooler.Release(this);
    }
}
