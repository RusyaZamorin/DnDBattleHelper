using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Calculator;
using Calculator.Operators;

namespace Application.CoreEntities
{
    public class Characteristic
    {        
        public string Name;
        public Texture2D Icon;
        public Function InitFunction = new Function(new Operand_Value(0f));
        public Function SetFunction = new Function(new Operannd_X());

        private double _valueData = 0;

        public Action OnChangedValue;
        public Action<Characteristic> OnChangedValueWithSender;

        public Characteristic(string name)
        {
            Name = name;
            _valueData = InitFunction.Calculate();
        }        

        public double Value
        {
            get => GetValue();
            set => SetValue(value);
        }

        public Characteristic Clone()
        {
            Characteristic newCharacteristic = new Characteristic(Name);
            newCharacteristic.Icon = Icon;
            newCharacteristic.InitFunction = InitFunction;
            newCharacteristic.SetFunction = SetFunction;
            return newCharacteristic;
        }

        protected virtual void SetValue(double value)
        {
            _valueData = SetFunction.Calculate(value);

            OnChangedValue?.Invoke();
            OnChangedValueWithSender?.Invoke(this);
        }

        protected virtual double GetValue()
        {
            return _valueData;
        }
                
    }
}

