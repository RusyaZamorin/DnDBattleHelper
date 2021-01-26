using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator
{
    public static class CharacteristicsCalculator
    {
        public static double CalculateInputToDouble(string input)
        {
            return ReverseNotationConverter.Calculate(input);
        }

        public static int CalculateInputToInt(string input)
        {
            return (int)CalculateInputToDouble(input);               
        }        
    }
}

