using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacteristicsCalculator;

namespace Application.GameObjectEntityImplementations
{
    public class EditableButton : MonoBehaviour
    {
        private Function _function;

        public void Init(Function function)
        {

        }

        public void SetFunction(Function function) => _function = function;
    }
}

