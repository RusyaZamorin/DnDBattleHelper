using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator.Operators
{
    public class OpMultiply : DefaultOperator
    {
        public OpMultiply() : base(null, null)
        {

        }

        public OpMultiply(IOperator leftOperand, IOperator rightOperand) : base(leftOperand, rightOperand)
        {
        }

        public override double GetValue() => LeftOperand.GetValue() * RightOperand.GetValue();

        public override string Symbol => "*";
    }
}

