using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class DamageButton : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _damage;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

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
        _playerHealth.Hit(_damage);
    }
}