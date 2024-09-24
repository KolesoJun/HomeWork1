using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Brick : MonoBehaviour
{
    public event UnityAction<Brick> Death;

    [SerializeField] private Color32[] _color;

    private bool _isFirstEnter;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isFirstEnter == false)
        {
            if (collision.gameObject.TryGetComponent<PlatformDestroyer>(out _))
            {
                _isFirstEnter = true;
                _meshRenderer.material.color = ChangeColor();
                StartCoroutine(CountdownLife());
            }
        }
    }

    public void Init()
    {
        _meshRenderer.material.color = Color.white;
        _isFirstEnter = false;
    }

    private Color32 ChangeColor()
    {
        int colorRandomMin = 0;
        int colorRandomMax = _color.Length;
        return _color[Random.Range(colorRandomMin, colorRandomMax)];
    }

    private IEnumerator CountdownLife()
    {
        float lifeTimeMin = 2f;
        float lifeTimeMax = 6f;
        yield return new WaitForSeconds(Random.Range(lifeTimeMin, lifeTimeMax));
        Death?.Invoke(this);
    }
}
