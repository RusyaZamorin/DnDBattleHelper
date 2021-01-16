using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator.Functions
{
    public class OpSin : DefaultOperator
    {
        public OpSin() : base(null, null)
        {

        }

        public OpSin(IOperator leftOperand) : base(leftOperand, null)
        {
        }

        public override double GetValue() => Mathf.Sin((float)LeftOperand.GetValue());

        public override string Symbol => "sin";
    }
}

