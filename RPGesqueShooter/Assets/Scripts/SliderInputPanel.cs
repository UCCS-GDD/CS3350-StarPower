using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class SliderInputPanel : MonoBehaviour
    {
        public Slider Slider;
        public InputField InputField;

        public float Min;
        public float Max;
        public float Value;

        public delegate void ValueChanged(float newValue);
        public event ValueChanged OnValueChanged;

        public void Start()
        {
            Slider.minValue = Min;
            Slider.maxValue = Max;
            Slider.value = Value;

            InputField.text = Value.ToString();
        }

        public void OnInputChanged(string newValue)
        {
            OnInputChanged(float.Parse(newValue));
        }

        public void OnInputChanged(float newValue)
        {
            if (Slider.wholeNumbers)
                Value = Mathf.Round(Value);

            Value = Mathf.Clamp(newValue, Min, Max);

            Slider.value = Value;
            InputField.text = Value.ToString();

            if (OnValueChanged != null)
                OnValueChanged(Value);
        }

        public void OnSliderChanged(float newValue)
        {
            Value = newValue;
            InputField.text = Value.ToString();

            if (OnValueChanged != null)
                OnValueChanged(Value);
        }

        public void UpdateRange(float newMin, float newMax)
        {
            Min = newMin;
            Max = newMax;

            Slider.minValue = newMin;
            Slider.maxValue = newMax;
            Slider.gameObject.transform.FindChild("Min").gameObject.GetComponent<Text>().text = newMin.ToString();
            Slider.gameObject.transform.FindChild("Max").gameObject.GetComponent<Text>().text = newMax.ToString();

            OnInputChanged(Value);
            OnSliderChanged(Value);
        }
    }
}
