using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public struct CustomSlider
{
    public Slider Slider;
    private TMP_Text TextInSlider;

    public float CurrentValue { get { return Slider.value; }}
    public float CurrentMaxValue { get { return Slider.maxValue; } }


    public CustomSlider(Slider slider)
    {
        Slider = slider;
        TextInSlider = Slider.transform.GetComponentInChildren<TMP_Text>() != null ? Slider.transform.GetComponentInChildren<TMP_Text>() : null;
    }



    public void MaxValueChange(float value, bool max = false)
    {
        Slider.maxValue = value;

        if(!max)
            ValueChange(0);
        else
            ValueChange(CurrentMaxValue);
 
    }

    public void ValueChange(float value, bool plus = true)
    {
        if (value == 0)
            Slider.value = 0;
        else
            Slider.value += plus ? value : -value;

        UpdateText();
    }

    private void UpdateText()
    {
        if(TextInSlider != null)
        TextInSlider.text = $"{CurrentValue} / {CurrentMaxValue}";
    }


}
