using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    public float HealthCurrent { get; private set; }

    private float _speedChange = 5f;
    private float _healthMax;
    private bool _canWork = true;

    private void Start()
    {
        HealthCurrent = _health;
        _healthMax = _health;
    }

    private IEnumerator ChangeHealth()
    {
        if (_canWork)
        {
            _canWork = false;
            CheckExcessHealth();
            CheckDeath();

            while (_health != HealthCurrent)
            {
                HealthCurrent = Mathf.MoveTowards(HealthCurrent, _health, _speedChange * Time.deltaTime);
                yield return new WaitForFixedUpdate();
            }

            StopCoroutine(ChangeHealth());
        }

        _canWork = true;
        yield return new WaitForFixedUpdate();
    }

    private void CheckExcessHealth()
    {
        if (_health >= _healthMax)
        {
            _health = _healthMax;
            StopCoroutine(ChangeHealth());
        }
    }

    private void CheckDeath()
    {
        if (_health <= 0)
        {
            StopCoroutine(ChangeHealth());
            Destroy(gameObject);
        }
    }

    public void Damage(float damage)
    {
        _health -= damage;
        StartCoroutine(ChangeHealth());
    }

    public void Hill(float bonusHeatlh)
    {
        _health += bonusHeatlh;
        StartCoroutine(ChangeHealth());
    }
}
