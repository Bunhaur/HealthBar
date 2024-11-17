using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextIndicator : MonoBehaviour, IShowable
{
    private TextMeshProUGUI _text;
    private float _maxValue;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void Show(float value)
    {
        _text.text = ($"{value}/{_maxValue}");
    }

    public void SetMaxValue(float value)
    {
        _maxValue = value;
    }
}
