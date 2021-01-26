using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator.Operators
{
    public class OpPlus : DefaultOperator
    {
        public OpPlus() : base(null, null)
        {

        }

        public OpPlus(IOperator leftOperand, IOperator rightOperand) : base(leftOperand, rightOperand)
        {            
        }

        public override double GetValue() => LeftOperand.GetValue() + RightOperand.GetValue();

        public override string Symbol => "+";
    }
}

