using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacteristicsCalculator.Operators
{
    public class OpMinus : BaseOperator
    {
        public OpMinus() : base(null, null)
        {

        }

        public OpMinus(IOperator leftOperand, IOperator rightOperand) : base(leftOperand, rightOperand)
        {
        }

        public override double GetValue() => LeftOperand.GetValue() - RightOperand.GetValue();

        public override string Symbol => "-";
    }
}
