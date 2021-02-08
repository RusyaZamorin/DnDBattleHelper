using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Application.CoreEntities
{
    public class Character
    {         
        private string _name = null;
        private int _index = 0;
        private List<Characteristic> _characteristics = new List<Characteristic>();

        public Action<Character> OnChangedName;
        public Action<Character> OnChangesName;
        public Action OnChangedIndex;
        public Action OnDelete;

        public Character(string name)
        {
            Name = name;
            Index = 0;            
        }

        public int Index
        {
            get { return _index; }
            set
            {
                _index = value;
                OnChangedIndex?.Invoke();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                OnChangesName?.Invoke(this);
                _name = value;
                OnChangedName?.Invoke(this);
            }
        }

        public List<Characteristic> Characteristics { get => _characteristics; }
        
        public void SetCharacteristicValue(string characteristicName, double value)
        {
            _characteristics.Find(characteristic => characteristic.Name == characteristicName).Value = value;
        }

        public double GetCharacteristicValue(string characteristicName)
        {
            return _characteristics.Find(characteristic => characteristic.Name == characteristicName).Value;
        }

        public Characteristic GetCharacteristic(string characteristicName)
        {
            return _characteristics.Find(characteristic => characteristic.Name == characteristicName);
        }

        public void Delete()
        {                        
            OnDelete?.Invoke();
        }

        public Character Copy()
        {
            Character characterCopy = new Character(Name);

            foreach (var characteristic in Characteristics)
            {
                characterCopy.Characteristics.Add(characteristic.Copy());
            }

            return characterCopy;
        }                
        
    }
}


