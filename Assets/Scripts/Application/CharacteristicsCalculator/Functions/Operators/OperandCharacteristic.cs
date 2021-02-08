using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application.CoreEntities;

namespace CharacteristicsCalculator.Operators
{
    public class OperandCharacteristic : BaseOperator
    {
        private string _characteristicName;

        public OperandCharacteristic() : base(null, null)
        {
            _characteristicName = "";
        }

        public OperandCharacteristic(string characteristicName) : base(null, null)
        {
            _characteristicName = characteristicName;
        }

        public override double GetValue()
        {
            if(_character == null)
            {
                Debug.Log("NULL CHARACTER");
                return 0f;
            }

            return _character.GetCharacteristicValue(_characteristicName);
        }

        public override void SetCharacter(Character character) => _character = character;        

        public override string Symbol => _characteristicName;

        public override IOperator Copy()
        {
            var copy = base.Copy();
            ((OperandCharacteristic)copy)._characteristicName = _characteristicName;
            return copy;
        }
    }
}

