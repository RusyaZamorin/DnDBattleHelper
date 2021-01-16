using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [Serializable]
    public class Character
    {
        private int _maxHitPoints = 1;
        private int _hitPoints = 1;        
        private int _bonusHitPoints = 0;
        private int _armorClass = 1;
        private int _initiative = 1;
        private string _name = "";

        public event Action<int> OnChangedMaxHitPoints;
        public event Action<int> OnChangedHitPoints;
        public event Action<int> OnChangedBonusHitPoints;
        public event Action<int> OnChangedArmorClass;
        public event Action<int> OnChangedInitiative;
        public event Action<string> OnChangedName;

        public int MaxHitPoints
        {
            get { return _maxHitPoints; }
            set 
            {
                if (value >= 1) _maxHitPoints = value;
                else _maxHitPoints = 1;

                if (_hitPoints > _maxHitPoints)
                    _hitPoints = _maxHitPoints;
                OnChangedMaxHitPoints?.Invoke(_maxHitPoints);
            }
        }
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                if (value >= _maxHitPoints) _hitPoints = _maxHitPoints;
                else if (value <= 0) _hitPoints = 0;
                else _hitPoints = value;
                OnChangedHitPoints?.Invoke(_hitPoints);
            }
        }
        public int BonusHitPoints
        {
            get { return _bonusHitPoints; }
            set
            {
                if (value >= 0) _bonusHitPoints = value;
                else _bonusHitPoints = 0;
                OnChangedBonusHitPoints?.Invoke(_bonusHitPoints);
            }
        }
        public int ArmorClass
        {
            get { return _armorClass; }
            set 
            {
                if (value >= 0) _armorClass = value;
                else _armorClass = 0;
                OnChangedArmorClass?.Invoke(_armorClass);
            }
        }
        public int Initiative 
        {
            get { return _initiative; }
            set 
            {
                if (value >= 0) _initiative = value;
                else _initiative = 0;
                OnChangedInitiative?.Invoke(_initiative);
            }
        }
        public string Name 
        {
            get { return _name; }
            set
            {
                if(value != null)
                {
                    _name = value;
                    OnChangedName?.Invoke(_name);
                }
            }
        }
        
        public Character Copy()
        {
            var copyCharacter = new Character();

            copyCharacter.MaxHitPoints = _maxHitPoints;
            copyCharacter.HitPoints = _hitPoints;
            copyCharacter.BonusHitPoints = _bonusHitPoints;
            copyCharacter.ArmorClass = _armorClass;
            copyCharacter.Initiative = _initiative;
            copyCharacter.Name = _name;

            return copyCharacter;
        }
    }
}


