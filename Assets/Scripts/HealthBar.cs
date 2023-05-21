using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] private Text _currentHealthText;

    private Slider _slider;
    private float _currentHealth;

    private void Start() => _slider = GetComponent<Slider>();

    private void Update()
    {
        _currentHealth = _player.CurrentHealth;
        _currentHealthText.text = $"{_currentHealth}/{_slider.maxValue}";
    }

    public void ChangeHealth(float value) => StartCoroutine(ChangeHealthBar(value));

    private IEnumerator ChangeHealthBar(float value)
    {
        while (_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _currentHealth, 25F * Time.deltaTime);
            yield return null;
        }
    }
}