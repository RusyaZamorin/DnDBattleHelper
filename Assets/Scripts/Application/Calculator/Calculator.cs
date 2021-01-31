using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacteristicsCalculator
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
    }
}

