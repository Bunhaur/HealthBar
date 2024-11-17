using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class HealButton : ButtonOfHealth
{
    private void OnEnable()
    {
        _button.onClick.AddListener(HealPlayer);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(HealPlayer);
    }

    private void HealPlayer()
    {
        _playerHealth.ChangeValue(_value);
    }
}