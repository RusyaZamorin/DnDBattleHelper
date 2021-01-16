using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator.Functions
{
    public class DefaultOperator : IOperator
    {
        public IOperator LeftOperand { get => _leftOperand; set => _leftOperand = value; }
        public IOperator RightOperand { get => _rightOperand; set => _rightOperand = value; }

        protected IOperator _leftOperand;
        protected IOperator _rightOperand;

        public DefaultOperator(IOperator leftOperand, IOperator rightOperand)
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
   
    }
}

