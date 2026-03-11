using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WidthController : MonoBehaviour
{
    public Slider widthSlider;
    public TMP_InputField widthInput;

    private bool isUpdating = false;

    void Start()
    {
        // Initialize input field with slider value
        UpdateUI(widthSlider.value);

        // Slider event
        widthSlider.onValueChanged.AddListener(OnSliderChanged);

        // Input field event
        widthInput.onEndEdit.AddListener(OnInputChanged);
    }

    void OnSliderChanged(float value)
    {
        if (isUpdating) return;

        isUpdating = true;
        UpdateUI(value);
        isUpdating = false;
    }

    void OnInputChanged(string value)
    {
        if (isUpdating) return;

        if (float.TryParse(value, out float result))
        {
            result = Mathf.Clamp(result, widthSlider.minValue, widthSlider.maxValue);

            isUpdating = true;

            widthSlider.value = result;
            UpdateUI(result);

            isUpdating = false;
        }
    }

    void UpdateUI(float value)
    {
        int intValue = Mathf.RoundToInt(value);

        widthInput.text = intValue.ToString();
    }
}