using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    public float HealthCurrent { get; private set; }

    private float _speedChange = 8f;
    private float _healthMax;

    private void Start()
    {
        HealthCurrent = _health;
        _healthMax = _health;
    }

    private void Update()
    {
        HealthCurrent = Mathf.MoveTowards(HealthCurrent, _health, _speedChange*Time.deltaTime);

        if (HealthCurrent <= 0)
            Destroy(gameObject);
    }

    public void ChangeHealth(float value)
    {
        if (_health + value >= _healthMax)
            _health = _healthMax;
        else
            _health += value;
    }
}
