using UnityEngine;

namespace Application.CharacteristicsCalculator.Functions.Operators
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

