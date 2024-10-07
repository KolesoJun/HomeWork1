using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private House _house;

    private float _step = 0.5f;
    private AudioSource _audioSource;
    private Coroutine _coroutine;
    private float _volumeTarget;
    private float _volumeMin = 0f;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        Init();
    }

    private void OnEnable()
    {
        _house.EnteredThief += IncreaseVolume;
        _house.OutThief += DecreaseVolume;
    }

    private void OnDisable()
    {
        _house.EnteredThief -= IncreaseVolume;
        _house.OutThief -= DecreaseVolume;
    }

    private void Play()
    {
        if (_coroutine != null)
            StopCoroutine(AdjustVolume());

        _coroutine = StartCoroutine(AdjustVolume()); 
    }

    private void IncreaseVolume()
    {
        _volumeTarget = 1f;
        _audioSource.Play();
        Play();
    }

    private void DecreaseVolume()
    {
        _volumeTarget = _volumeMin;
        Play();
    }

    private void OffSound()
    {
        if (_audioSource.volume == _volumeMin)
            _audioSource.Stop();
    }

    private void Init()
    {
        _audioSource.clip = _clip;
        _audioSource.volume = _volumeMin;
    }

    private IEnumerator AdjustVolume()
    {
        while (_audioSource.volume != _volumeTarget)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _volumeTarget, _step * Time.deltaTime);
            yield return null;
        }

        OffSound();
    }
}
