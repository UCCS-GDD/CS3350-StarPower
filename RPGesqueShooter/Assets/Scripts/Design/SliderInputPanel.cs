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
        // Variables for Sldier and InputField
        public Slider Slider;
        public InputField InputField;

        // Variables for minimum and maximum values
        public float Min;
        public float Max;
        public float Value;

        //
        public delegate void ValueChanged(float newValue);
        public event ValueChanged OnValueChanged;

        // Use this for initialization
        public void Start()
        {
            // set the values of the Slider
            Slider.minValue = Min;
            Slider.maxValue = Max;
            Slider.value = Value;

            // set the text of the InputField
            InputField.text = Value.ToString();
        }

        // When the Input changes value
        public void OnInputChanged(string newValue)
        {
            // Parse new value
            OnInputChanged(float.Parse(newValue));
        }

        // When the Input changes value
        public void OnInputChanged(float newValue)
        {
            // is the slider has wholeNumbers
            if (Slider.wholeNumbers)
                // round the values
                Value = Mathf.Round(Value);

            // clamp the values with Min and Max
            Value = Mathf.Clamp(newValue, Min, Max);

            // set the Slider value to the new value
            Slider.value = Value;

            // set the InputField text to te new value
            InputField.text = Value.ToString();

            // if value changes is not null
            if (OnValueChanged != null)
                // set value to the value
                OnValueChanged(Value);
        }

        // When the slider changes values
        public void OnSliderChanged(float newValue)
        {
            // set the value to the newValue
            Value = newValue;
            
            // set the InputField text to the new value
            InputField.text = Value.ToString();

            // if value changed is not null
            if (OnValueChanged != null)
                // set the value to the new value
                OnValueChanged(Value);
        }

        // Updates the values
        // Min and Max
        public void UpdateRange(float newMin, float newMax)
        {
            // set Min and Max to their new values
            Min = newMin;
            Max = newMax;

            // set the Sliders min and max values to their new values
            Slider.minValue = newMin;
            Slider.maxValue = newMax;

            // finds the slider min and max componenets
            // set the text to the new values
            Slider.gameObject.transform.FindChild("Min").gameObject.GetComponent<Text>().text = newMin.ToString();
            Slider.gameObject.transform.FindChild("Max").gameObject.GetComponent<Text>().text = newMax.ToString();

            // Change the values depending on the input
            OnInputChanged(Value);
            OnSliderChanged(Value);
        }

		public bool ChangeCredits(String name, float newValue)
		{
			return false;
		}
    }
}
