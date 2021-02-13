namespace Application.CharacteristicsCalculator.Functions.Operators
{
    public class OpPlus : BaseOperator
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

