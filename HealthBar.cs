using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _slider;
    private float _percent = 100f;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public void Update()
    {
            _slider.value = _player.HealthCurrent / _percent;
    }
}
