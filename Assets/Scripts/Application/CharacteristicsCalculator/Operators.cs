using System;
using System.Collections.Generic;
using Application.CharacteristicsCalculator.Functions.Operators;

namespace Application.CharacteristicsCalculator
{
    public static class OperatorsBar
    {
        public static List<string> ListSymbols { get; } = new List<string>(_operatorsTypes.Keys);

        private static List<string> _characteristicsNames = new List<string>();

        public static string XSymbol => "x";

        public static bool IsOperator(string symbol)
        {
            return ListSymbols.Contains(symbol);
        }

        public static bool IsX(string symbol)
        {
            return symbol == "x" || symbol == "X";
        }

        public static bool IsCharacteristic(string symbol)
        {
            return _characteristicsNames.Contains(symbol);
        }

        public static IOperator GetOperator(string symbol)
        {                        
            return (IOperator)Activator.CreateInstance(_operatorsTypes[symbol]);
        }

        public static bool IsUnaryOperator(IOperator opert)
        {
            var type = opert.GetType();
            return type == typeof(OpSin) ||
                   type == typeof(OpCos) ||
                   type == typeof(OpUnaryMinus);
        }

        public static bool IsBinaryOperator(IOperator opert) => !IsUnaryOperator(opert);        

        private static Dictionary<string, Type> _operatorsTypes = new Dictionary<string, Type>()
        {
            {"(", null},
            { ")", null},
            {"+", typeof (OpPlus)},
            {"-", typeof (OpMinus)},
            {"*", typeof (OpMultiply)},
            {"/", typeof (OpSplit)},
            {"^", typeof (OpPow)},
            {"sin", typeof (OpSin)},
            {"cos", typeof (OpCos)},
            {"um", typeof (OpUnaryMinus)},
            {"d", typeof (OpDice)}
        };
    }    
}