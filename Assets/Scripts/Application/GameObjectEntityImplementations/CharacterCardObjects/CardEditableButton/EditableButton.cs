using System.Collections;
using System.Collections.Generic;
using Application.CharacteristicsCalculator;
using UnityEngine;
using Application.CoreEntities;

namespace Application.GameObjectEntityImplementations
{
    public class EditableButton : MonoBehaviour
    {
        private Character _character;
        private IList _actions = new List<ActionOnCharacteristic>();
        private string _input = "";

        public void Init()
        {

        }

        public void ExecuteActions()
        {
            if (_character == null)
                return;

            foreach(ActionOnCharacteristic action in _actions)
            {
                if (_input != "")
                {
                    action.Execute(_character, Calculator.CalculateInputToDouble(_input));
                }
                else
                {
                    action.Execute(_character, 0f);
                }
            }
        }
    }
}

