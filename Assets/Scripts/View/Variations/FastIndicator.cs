using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class FastIndicator : MonoBehaviour, IShowable
{
    private Slider _slider;

    public void Show(float value)
    {
        _slider.value = value;
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
}