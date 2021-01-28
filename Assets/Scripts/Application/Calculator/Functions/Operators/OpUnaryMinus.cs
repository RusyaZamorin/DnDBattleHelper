using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator.Operators
{
    public class OpUnaryMinus : DefaultOperator
    {
        public OpUnaryMinus() : base(null, null)
        {

        }

        public OpUnaryMinus(IOperator leftOperand) : base(leftOperand, null)
        {
        }

        public override double GetValue() => -LeftOperand.GetValue();

        public override string Symbol => "um";
    }

}
