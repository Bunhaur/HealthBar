using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float _minValue = 0;

    public event Action<float> Changed;

    [field: SerializeField] public float MaxValue { get; private set; } = 100;
    [field: SerializeField] public float CurrentValue { get; private set; } = 100;

    public void ChangeValue(float value)
    {
        CurrentValue = Mathf.Clamp(CurrentValue += value, _minValue, MaxValue);

        Changed?.Invoke(CurrentValue);
    }
}