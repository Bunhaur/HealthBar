using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DamageButton : ButtonOfHealth
{
    private void OnEnable()
    {
        _button.onClick.AddListener(HitPlayer);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(HitPlayer);
    }

    private void HitPlayer()
    {
        _playerHealth.ChangeValue(-_value);
    }
}