using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class Player : MonoBehaviour
{
    private Slider _health;

    private float _maxHealth;
    private float _minHealth;
    private float _damage;
    private float _heal;
    private float _currentHealth;
    private float _changeSpeed;

    private void Start()
    {
        _health = GetComponent<Slider>();

        _maxHealth = 100f;
        _minHealth = 0.0f;
        _health.value = _maxHealth;
        _damage = 10f;
        _heal = 10f;
        _currentHealth = _health.value;
        _changeSpeed = 25f;
    }

    public void TakeDamage()
    {
        if (_currentHealth > _minHealth)
            _currentHealth -= _damage;
        else
            _currentHealth = _minHealth;

        StartCoroutine(HealthChanged());
    }

    public void TakeHealing()
    {
        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
        else
            _currentHealth += _heal;

        StartCoroutine(HealthChanged());
    }

    private IEnumerator HealthChanged()
    {
        while (_health.value != _currentHealth)
        {
            _health.value = Mathf.MoveTowards(_health.value, _currentHealth, _changeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}