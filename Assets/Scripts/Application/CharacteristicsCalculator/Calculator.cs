using Application.CharacteristicsCalculator.Functions;

namespace Application.CharacteristicsCalculator
{
    public static class Calculator
    {
        public static double CalculateInputToDouble(string input)
        {
            return PolishNotationConverter.Calculate(input);
        }

        public static int CalculateInputToInt(string input)
        {
            return (int)CalculateInputToDouble(input);               
        }

        public static Function CreateFunction(string input)
        {
            return PolishNotationConverter.CreateFunction(input);
        }
    }
}

