using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthPoint : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI displayValue;

    public void Render(int hp)
    {
        slider.value = (float)hp / 100f;
        displayValue.text = hp.ToString();
    }
}
