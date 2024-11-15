using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [field: SerializeField] public float MaxHealth { get; private set; } = 100;
    [field: SerializeField] public float Health { get; private set; } = 100;

    private float _minHealth = 0;

    public event Action<float> HealthChanged;

    public void Hit(float value)
    {
        Health = Mathf.Clamp(Health -= value, _minHealth, MaxHealth);
        HealthChanged?.Invoke(Health);
    }

    public void Heal(float value)
    {
        Health = Mathf.Clamp(Health += value, _minHealth, MaxHealth);
        HealthChanged?.Invoke(Health);
    }
}