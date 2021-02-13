using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Application.CharacteristicsCalculator;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Application.CoreEntities;

namespace Application.GameObjectEntityImplementations
{
    public class CharacteristicPanel : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private TMP_Text _nameField;
        [SerializeField] private Image _icon;

        private Characteristic _characteristic;


        public void SetValue(double value) => _characteristic.Value = value;

        public void SetValue(string input) => SetValue(Calculator.CalculateInputToDouble(input));

        public void AddToValue(double addValue) => _characteristic.Value += addValue;

        public void Init(Characteristic characteristic)
        {
            _characteristic = characteristic;

            _nameField.text = characteristic.Name;
            _inputField.text = characteristic.Value.ToString(CultureInfo.InvariantCulture);            
            _characteristic.OnChangedValue += UpdateValue;
            if (characteristic.Icon != null)
                _icon.sprite = characteristic.Icon;
        }

        private void UpdateValue() => _inputField.text = _characteristic.Value.ToString(CultureInfo.InvariantCulture);

    }
}

