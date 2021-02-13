using UnityEngine;

namespace Application.CharacteristicsCalculator.Functions.Operators
{
    public class OpPow : BaseOperator
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

