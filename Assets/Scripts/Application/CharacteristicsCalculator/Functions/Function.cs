using Application.CharacteristicsCalculator.Functions.Operators;
using Application.CoreEntities;

namespace Application.CharacteristicsCalculator.Functions
{
    public class Function
    {
        private readonly IOperator _funcOperator;

        public Function(IOperator funcOperator) => _funcOperator = funcOperator;        

        public double Calculate(double variable = 0, Character character = null)
        {
            _funcOperator.SetX(variable);
            _funcOperator.SetCharacter(character);
            return _funcOperator.GetValue();
        }

        public Function Copy()
        {            
            return new Function(_funcOperator.Copy());
        }
    }
}

