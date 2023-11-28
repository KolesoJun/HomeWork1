using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction<float> HealthChanged;

    [SerializeField] private float _health;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);
        CheckDeath();
    }

    public void ApplyHealths(float bonusHeatlh)
    {
        _health += bonusHeatlh;
        HealthChanged?.Invoke(_health);
    }

    private void CheckDeath()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
