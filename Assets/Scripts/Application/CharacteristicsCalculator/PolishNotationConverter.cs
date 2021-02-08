using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CharacteristicsCalculator.Operators;

namespace CharacteristicsCalculator
{
    public class PolishNotationConverter 
    {
        public static string FromString(string input)
        {
            string output = string.Empty;
            Stack<string> operStack = new Stack<string>();
            bool lastNoteIsOperator = true;
            string complexityOperator = "";

            for (int i = 0; i < input.Length; i++)
            {                
                if (IsDelimeter(input[i].ToString()))
                    continue;
                
                if (input[i] == '-' && lastNoteIsOperator == true)
                {
                    operStack.Push("um");
                }
                
                else if (char.IsDigit(input[i]))
                {                    
                    while (!IsDelimeter(input[i].ToString()) && !IsOperator(input[i].ToString()))
                    {
                        output += input[i];
                        i++;
                        if (i == input.Length) break;
                    }

                    output += " ";
                    i--;
                    lastNoteIsOperator = false;
                }
                else if (IsOperator(input[i].ToString()))
                {
                    if (input[i] == '(')
                        operStack.Push(input[i].ToString());
                    else if (input[i] == ')')
                    {                        
                        string s = operStack.Pop();
                        while (s != "(")
                        {
                            output += s + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else
                    {
                        if (operStack.Count > 0)
                            if (GetPriority(input[i].ToString()) <= GetPriority(operStack.Peek()))
                            {
                                output += operStack.Pop().ToString() + " "; 
                            }

                        operStack.Push(input[i].ToString());
                    }

                    lastNoteIsOperator = true;
                }
                
                else if (OperatorsBar.IsX(input[i].ToString()))
                {
                    output += OperatorsBar.XSymbol + " ";

                    lastNoteIsOperator = false;
                }
                
                else
                {
                    complexityOperator += input[i];

                    if (OperatorsBar.IsOperator(complexityOperator))
                    {
                        operStack.Push(complexityOperator);
                        complexityOperator = "";

                        lastNoteIsOperator = true;
                    }
                    else if(OperatorsBar.IsCharacteristic(complexityOperator))
                    {
                        output += complexityOperator + " ";
                        complexityOperator = "";

                        lastNoteIsOperator = false;
                    }
                }
            }
            
            while (operStack.Count > 0)
                output += operStack.Pop() + " ";

            Debug.Log(output);

            return output;
        }

        public static double Calculate(string input)
        {
            return CalculatePolishNotation(FromString(input));
        }

        public static Function CreateFunction(string input)
        {
            return CreateFunctionFromNotation(FromString(input));
        }

        private static Function CreateFunctionFromNotation(string notation)
        {
            char[] separator = { ' ' };

            List<string> polishNotationList = new List<string>(notation.
                Split(separator, StringSplitOptions.RemoveEmptyEntries));

            Stack<IOperator> operatorsStack = new Stack<IOperator>();
            IOperator firstOperator = null;

            foreach (string notationElement in polishNotationList)
            {
                if (OperatorsBar.IsOperator(notationElement))
                {
                    IOperator opert = OperatorsBar.GetOperator(notationElement);

                    if (OperatorsBar.IsUnaryOperator(opert))
                    {
                        opert.LeftOperand = operatorsStack.Pop();
                    }
                    else
                    {
                        opert.RightOperand = operatorsStack.Pop();
                        opert.LeftOperand = operatorsStack.Pop();
                    }

                    operatorsStack.Push(opert);
                }
                else if (OperatorsBar.IsX(notationElement))
                {
                    operatorsStack.Push(new OperandX());
                }
                else if(OperatorsBar.IsCharacteristic(notationElement))
                {
                    operatorsStack.Push(new OperandCharacteristic(notationElement));
                }
                else
                {
                    operatorsStack.Push(new OperandValue(double.Parse(notationElement)));
                }
            }

            firstOperator = operatorsStack.Pop();
            
            return new Function(firstOperator);
        }

        private static double CalculatePolishNotation(string notation)
        {
            return CreateFunctionFromNotation(notation).Calculate();
        }

        static private bool IsDelimeter(string symbol)
        {
            if ((" =".IndexOf(symbol) != -1))
                return true;
            return false;
        }

        static private bool IsOperator(string symbol) 
        {
            return OperatorsBar.ListSymbols.Contains(symbol);

        }

        static private int GetPriority(string symbol)
        {
            if (OperatorsBar.ListSymbols.Contains(symbol))
                return OperatorsBar.ListSymbols.IndexOf(symbol);
            else
                return OperatorsBar.ListSymbols.Count;
        }
    }
}

