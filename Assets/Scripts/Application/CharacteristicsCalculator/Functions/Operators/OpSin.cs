using UnityEngine;

namespace Application.CharacteristicsCalculator.Functions.Operators
{
    public class OpSin : BaseOperator
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

