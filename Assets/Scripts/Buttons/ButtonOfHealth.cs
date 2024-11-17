using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ButtonOfHealth : MonoBehaviour
{
    [SerializeField] protected PlayerHealth _playerHealth;
    [SerializeField] protected float _value;

    protected Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }
}