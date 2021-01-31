using Calculator.Operators;

namespace Calculator
{
    public class Function
    {
        private IOperator _funcOperator;

        public Function(IOperator funcOperator) => _funcOperator = funcOperator;        

        public double Calculate(double x = 0)
        {
            _funcOperator.SetX(x);
            return _funcOperator.GetValue();
        }

        public Function Copy()
        {            
            return new Function(_funcOperator.Copy());
        }
    }
}

