using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator.Operators
{
    public class OpPow : DefaultOperator
    {
        public OpPow() :base(null, null)
        {

        }

        public OpPow(IOperator leftOperand, IOperator rightOperand) : base(leftOperand, rightOperand)
        {
        }

        public override double GetValue() => Mathf.Pow((float)LeftOperand.GetValue(), (float)RightOperand.GetValue());

        public override string Symbol => "^";
    }
}

