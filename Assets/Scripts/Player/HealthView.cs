using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textHealth;
    [SerializeField] private Slider _valueHealthBar;
    [SerializeField] private Slider _smoothHealthBar;
    [SerializeField] private PlayerHealth _playerHealth;

    private Coroutine _smoothIncreaseValueJob;
    private float _speedChange = 50f;
    private float _maxHealth;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        _playerHealth.HealthChanged += ShowHealthFast;
        _playerHealth.HealthChanged += ShowHealthSmooth;
        _playerHealth.HealthChanged += ShowHealthText;
    }

    private void OnDisable()
    {
        _playerHealth.HealthChanged -= ShowHealthFast;
        _playerHealth.HealthChanged -= ShowHealthSmooth;
        _playerHealth.HealthChanged -= ShowHealthText;
    }

    private void Init()
    {
        _maxHealth = _playerHealth.MaxHealth;

        ShowHealthFast(_playerHealth.Health);
        ShowHealthSmooth(_playerHealth.Health);
        ShowHealthText(_playerHealth.Health);
    }

    private void ShowHealthFast(float value)
    {
        _valueHealthBar.value = value;
    }

    private void ShowHealthSmooth(float value)
    {
        if (_smoothIncreaseValueJob != null)
            StopCoroutine(_smoothIncreaseValueJob);

        _smoothIncreaseValueJob = StartCoroutine(SmoothIncreaseValue(value));
    }

    private IEnumerator SmoothIncreaseValue(float value)
    {
        while (_smoothHealthBar.value != value)
        {
            _smoothHealthBar.value = Mathf.MoveTowards(_smoothHealthBar.value, value, _speedChange * Time.deltaTime);

            yield return null;
        }

        _smoothIncreaseValueJob = null;
    }

    private void ShowHealthText(float value)
    {
        _textHealth.text = ($"{value}/{_maxHealth}");
    }
}