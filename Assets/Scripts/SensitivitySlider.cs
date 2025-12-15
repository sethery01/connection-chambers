using UnityEngine;
using UnityEngine.UI;

public class SensitivitySlider : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        slider.value = GameSettings.MouseSensitivity;
        slider.onValueChanged.AddListener(SetSensitivity);
    }

    void SetSensitivity(float value)
    {
        GameSettings.MouseSensitivity = value;
    }
}
