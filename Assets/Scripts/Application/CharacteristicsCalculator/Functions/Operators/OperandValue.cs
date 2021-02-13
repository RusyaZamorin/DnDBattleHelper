namespace Application.CharacteristicsCalculator.Functions.Operators
{
    public class OperandValue : BaseOperator
    {
        private double _value;

        public OperandValue() : base(null, null)
        {
            _value = 0f;
        }

        public OperandValue(double value) : base(null,null)
        {
            _value = value;
        }

        public override double GetValue()
        {
            return _value;
        }

        public override void SetX(double x)
        {
            return;
        }

        public override string Symbol => _value.ToString();

        public override IOperator Copy()
        {
            var copy = base.Copy();
            ((OperandValue)copy)._value = _value;
            return copy;
        }
    }

}
