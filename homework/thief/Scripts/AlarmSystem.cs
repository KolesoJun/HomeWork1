using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private House _house;

    private float _step = 0.5f;
    private AudioSource _audioSource;
    private float _volumeTarget;
    private float _volumeMin = 0f;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _house.LoggedThief += AdjustVolume;
    }

    private void Start()
    {
        _audioSource.clip = _clip;
        _audioSource.volume = _volumeMin;
    }

    private void Update()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _volumeTarget, _step * Time.deltaTime);
    }

    private void OnDisable()
    {
        _house.LoggedThief -= AdjustVolume;
    }

    private void AdjustVolume(bool isInside)
    {
        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        if (isInside)
            _volumeTarget = 1f;
        else
            _volumeTarget = _volumeMin;
    }
}
