using CharacteristicsCalculator.Operators;

namespace CharacteristicsCalculator
{
    public class Function
    {
        private IOperator _funcOperator;

        public Function(IOperator funcOperator) => _funcOperator = funcOperator;        

        public double Calculate(double variable = 0)
        {
            _funcOperator.SetX(variable);
            return _funcOperator.GetValue();
        }

        public Function Copy()
        {            
            return new Function(_funcOperator.Copy());
        }
    }
}

