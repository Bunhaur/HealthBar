using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private TextIndicator _text;
    [SerializeField] private FastIndicator _fast;
    [SerializeField] private SmoothIndicator _smooth;

    private void Start()
    {
        Init();
    }

    private void OnEnable()
    {
        _playerHealth.Changed += _text.Show;
        _playerHealth.Changed += _fast.Show;
        _playerHealth.Changed += _smooth.Show;
    }

    private void OnDisable()
    {
        _playerHealth.Changed -= _text.Show;
        _playerHealth.Changed -= _fast.Show;
        _playerHealth.Changed -= _smooth.Show;
    }

    private void Init()
    {
        _text.SetMaxValue(_playerHealth.MaxValue);

        _text.Show(_playerHealth.CurrentValue);
        _fast.Show(_playerHealth.CurrentValue);
        _smooth.Show(_playerHealth.CurrentValue);
    }
}