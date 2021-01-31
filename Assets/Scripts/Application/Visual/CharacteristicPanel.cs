using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Application.CoreEntities;
using Calculator;

namespace Application.Visual
{
    public class CharacteristicPanel : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private TMP_Text _nameField;
        [SerializeField] private Image _icon;

        private Characteristic _characteristic;


        public void SetValue(double value) => _characteristic.Value = value;

        public void SetValue(string input) => SetValue(CharacteristicsCalculator.CalculateInputToDouble(input));

        public void AddToValue(double addValue) => _characteristic.Value += addValue;

        public void Init(Characteristic characteristic)
        {
            _characteristic = characteristic;

            _nameField.text = characteristic.Name;
            _inputField.text = characteristic.Value.ToString();            
            _characteristic.OnChangedValue += UpdateValue;
            if (characteristic.Icon != null)
                _icon.sprite = characteristic.Icon;
        }

        private void UpdateValue() => _inputField.text = _characteristic.Value.ToString();

    }
}

