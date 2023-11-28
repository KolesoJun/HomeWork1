using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speedChange;

    private Slider _slider;
    private float _percent = 100f;
    private Coroutine _changeHealth;
    
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _player.HealthChanged += TryChangeHealth;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= TryChangeHealth;
    }

    private void TryChangeHealth(float health)
    {
        if (_changeHealth != null)
        {
            StopCoroutine(_changeHealth);
        }

        _changeHealth = StartCoroutine(ChangeValueSlider(health));
    }

    private IEnumerator ChangeValueSlider(float health)
    {
        while (_slider.value != health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health/ _percent, _speedChange * Time.deltaTime);
            yield return null;
        }
    }
}
