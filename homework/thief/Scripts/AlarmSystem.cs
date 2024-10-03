using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    private float _step = 0.5f;
    private AudioSource _audioSource;
    private float _volumeTarget;
    private float _volumeMin = 0f;
    private bool _isInside;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.clip = _clip;
        _audioSource.volume = _volumeMin;
    }

    private void Update()
    {
        AdjustVolume();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
        {
            _isInside = true;
            _audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
            _isInside = false;
    }

    private void AdjustVolume()
    {
        if (_isInside)
            _volumeTarget = 1f;
        else
            _volumeTarget = _volumeMin;

        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _volumeTarget, _step * Time.deltaTime);
    }
}
