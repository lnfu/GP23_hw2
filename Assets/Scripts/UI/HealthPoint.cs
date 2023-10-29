using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthPoint : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI displayValue;

    /// <summary>
    /// 血量：0-100
    /// </summary>
    /// <param name="value"></param>
    public void SetValue(int value)
    {
        slider.value = (float)value / 100f;
        displayValue.text = value.ToString();
    }

    void Start()
    {
        SetValue(50);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
