using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class HealButton : MonoBehaviour
{
    [SerializeField] private float _heal;
    [SerializeField] private PlayerHealth _playerHealth;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

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
        _playerHealth.ChangeValue(_heal);
    }
}