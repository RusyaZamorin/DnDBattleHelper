using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application.CoreEntities;

namespace CharacteristicsCalculator.Operators
{
    public abstract class BaseOperator : IOperator
    {
        public IOperator LeftOperand { get => _leftOperand; set => _leftOperand = value; }
        public IOperator RightOperand { get => _rightOperand; set => _rightOperand = value; }

        protected IOperator _leftOperand;
        protected IOperator _rightOperand;
        protected Character _character;

        public BaseOperator(IOperator leftOperand, IOperator rightOperand)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
        }

        public virtual string Symbol => "df";

        public virtual double GetValue()
        {
            return 0f;
        }

        public virtual void SetX(double x)
        {
            if(_leftOperand != null)
                _leftOperand.SetX(x);
            if (_rightOperand != null)
                _rightOperand.SetX(x);
        }

        public virtual void SetCharacter(Character character)
        {
            if (_leftOperand != null)
                _leftOperand.SetCharacter(character);
            if (_rightOperand != null)
                _rightOperand.SetCharacter(character);
        }

        public virtual IOperator Copy()
        {
            IOperator operatorCopy = (IOperator)Activator.CreateInstance(GetType());
            if (_leftOperand != null)
                operatorCopy.LeftOperand = _leftOperand.Copy();

            if(_rightOperand != null)
                operatorCopy.RightOperand = _rightOperand.Copy();

            return operatorCopy;
        }
    }
}

