using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Application.CharacteristicsCalculator.Functions;
using Application.CharacteristicsCalculator.Functions.Operators;

namespace Application.CoreEntities
{
    public class Characteristic
    {        
        public readonly string Name;
        public Sprite Icon;
        private Function _initFunction = new Function(new OperandValue(0f));
        private Function _setFunction = new Function(new OperandX());

        private double _valueData = 0;

        public Action OnChangedValue;
        public Action<Characteristic> OnChangedValueWithSender;

        protected Characteristic(string name)
        {
            Name = name;
            _valueData = _initFunction.Calculate();
        }        

        public double Value
        {
            get => GetValue();
            set => SetValue(value);
        }

        public Characteristic Copy()
        {
            var newCharacteristic = new Characteristic(Name)
            {
                Icon = Icon, _initFunction = _initFunction, _setFunction = _setFunction, _valueData = _valueData
            };
            return newCharacteristic;
        }

        protected virtual void SetValue(double value)
        {
            _valueData = _setFunction.Calculate(value);

            OnChangedValue?.Invoke();
            OnChangedValueWithSender?.Invoke(this);
        }

        protected virtual double GetValue()
        {
            return _valueData;
        }
                
    }
}

