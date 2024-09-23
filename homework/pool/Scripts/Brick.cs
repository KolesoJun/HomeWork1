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
    private Coroutine _coroutine;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlatformDestroyer>(out _) && _isFirstEnter == false)
        {
            _isFirstEnter = true;
            _meshRenderer.material.color = ChangeColor();
            Touch();
        }
    }

    public void Init()
    {
        _meshRenderer.material.color = Color.white;
        _isFirstEnter = false;
    }

    private void Touch()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CountdownLife());
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
        WaitForSeconds wait = new WaitForSeconds(Random.Range(lifeTimeMin, lifeTimeMax));
        yield return wait;
        Death?.Invoke(GetComponent<Brick>());
    }
}
