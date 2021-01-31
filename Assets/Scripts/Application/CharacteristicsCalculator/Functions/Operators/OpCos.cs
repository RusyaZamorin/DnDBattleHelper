using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacteristicsCalculator.Operators
{
    public class OpCos : BaseOperator
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

