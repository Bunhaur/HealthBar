using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private float _damage;
    [SerializeField] private float _heal;

    private float _maxHealth;
    private float _minHealth;
    private float _currentHealth;

    public float CurrentHealth => _currentHealth;

    private void Start()
    {
        _maxHealth = 100f;
        _minHealth = 0f;
        _damage = 10f;
        _heal = 10f;
        _currentHealth = _maxHealth;
    }

    public void TakeDamage()
    {
        _currentHealth = Mathf.Clamp(_currentHealth - _damage, _minHealth, _maxHealth);

        _healthBar.ChangeHealth(_currentHealth);
    }

    public void TakeHealth()
    {
        _currentHealth = Mathf.Clamp(_currentHealth + _heal, _minHealth, _maxHealth);

        _healthBar.ChangeHealth(_currentHealth);
    }
}