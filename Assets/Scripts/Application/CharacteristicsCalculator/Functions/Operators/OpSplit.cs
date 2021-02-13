using UnityEngine;

namespace Application.CharacteristicsCalculator.Functions.Operators
{
    public class OpSplit : BaseOperator
    {
        public OpSplit() : base(null, null)
        {

        }

        public OpSplit(IOperator leftOperand, IOperator rightOperand) : base(leftOperand, rightOperand)
        {
        }

        public override double GetValue()
        {
            if (RightOperand.GetValue() == 0f)
            {
                Debug.Log("Error split on zerro");
                return 0f;
            }                
            else
                return LeftOperand.GetValue() / RightOperand.GetValue();
        }
        public override string Symbol => "/";
    }
}
