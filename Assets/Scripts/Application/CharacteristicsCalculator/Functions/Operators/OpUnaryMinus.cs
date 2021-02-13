namespace Application.CharacteristicsCalculator.Functions.Operators
{
    public class OpUnaryMinus : BaseOperator
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
