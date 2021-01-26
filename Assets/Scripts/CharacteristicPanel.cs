using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core;

public class CharacteristicPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TMP_Text _nameField;

    private Characteristic _characteristic;


    public void SetValue(double value) => _characteristic.Value = value;

    public void SetValue(string value) => SetValue(double.Parse(value));
    
    public void AddToValue(double addValue) => _characteristic.Value += addValue;

    public void Init(Characteristic characteristic)
    {
        _characteristic = characteristic;

        _nameField.text = characteristic.Name;
        _inputField.text = characteristic.Value.ToString();

        _characteristic.OnChangedValue += UpdateValue;    
    }

    private void UpdateValue() => _inputField.text = _characteristic.Value.ToString();
    
}
