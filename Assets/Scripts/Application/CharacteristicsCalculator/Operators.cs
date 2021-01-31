using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CharacteristicsCalculator.Operators;

namespace CharacteristicsCalculator
{
    public class OperatorsBar
    {
        public static List<string> ListSymbols
        {
            get
            {
                return _symbolsList;
            }
        }

        public static string XSymbol => "x";

        public static bool IsOperator(string symbol)
        {
            if (_symbolsList.Contains(symbol))
                return true;
            else return false;
        }

        public static bool IsX(string symbol)
        {
            return symbol == "x" || symbol == "X";
        }

        public static IOperator GetOperator(string symbol)
        {
            return (IOperator)Activator.CreateInstance(_operatorsTypes[symbol]);
        }

        public static bool IsUnaryOperator(IOperator opert)
        {
            var type = opert.GetType();
            if (type == typeof(OpSin) ||
               type == typeof(OpCos) ||
               type == typeof(OpUnaryMinus)
               )
            {
                return true;
            }
            return false;
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

        private static List<string> _symbolsList = new List<string>(_operatorsTypes.Keys);
    }    
}