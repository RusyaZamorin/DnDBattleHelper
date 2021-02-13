using System;
using Application.CoreEntities;

namespace Application.CharacteristicsCalculator.Functions.Operators
{
    public abstract class BaseOperator : IOperator
    {
        public IOperator LeftOperand { get => _leftOperand; set => _leftOperand = value; }
        public IOperator RightOperand { get => _rightOperand; set => _rightOperand = value; }

        protected IOperator _leftOperand;
        protected IOperator _rightOperand;
        protected Character _character;

        protected BaseOperator(IOperator leftOperand, IOperator rightOperand)
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
            _leftOperand?.SetX(x);
            _rightOperand?.SetX(x);
        }

        public virtual void SetCharacter(Character character)
        {
            _leftOperand?.SetCharacter(character);
            _rightOperand?.SetCharacter(character);
        }

        public virtual IOperator Copy()
        {
            var operatorCopy = (IOperator)Activator.CreateInstance(GetType());
            if (_leftOperand != null)
                operatorCopy.LeftOperand = _leftOperand.Copy();

            if(_rightOperand != null)
                operatorCopy.RightOperand = _rightOperand.Copy();

            return operatorCopy;
        }
    }
}

