using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator.Operators
{
    public class OpCos : DefaultOperator
    {
        public OpCos() : base(null, null)
        {

        }

        public OpCos(IOperator leftOperand) : base(leftOperand, null)
        {
        }

        public override double GetValue() => Mathf.Cos((float)LeftOperand.GetValue());

        public override string Symbol => "cos";
    }
}

