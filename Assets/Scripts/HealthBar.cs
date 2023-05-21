using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] private Text _currentHealthText;

    private Slider _slider;
    private Coroutine _changeHealthBarJob;

    private float _currentHealth;
    private float _sliderChangeSpeed;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _currentHealth = _player.CurrentHealth;
        _sliderChangeSpeed = 35f;

        ShowCurrentHealthToText();
    }

    public void ChangeHealth()
    {
        _currentHealth = _player.CurrentHealth;

        if (_changeHealthBarJob == null)
        {
            _changeHealthBarJob = StartCoroutine(ChangeHealthBar());
        }
    }

    private void ShowCurrentHealthToText() => _currentHealthText.text = $"{_currentHealth}/{_slider.maxValue}";

    private IEnumerator ChangeHealthBar()
    {
        while (_slider.value != _currentHealth)
        {
            ShowCurrentHealthToText();

            _slider.value = Mathf.MoveTowards(_slider.value, _currentHealth, _sliderChangeSpeed * Time.deltaTime);
            yield return null;
        }

        _changeHealthBarJob = null;
    }
}