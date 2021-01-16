using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Calculator.Functions;

namespace Calculator
{
    public class ReverseNotationConverter 
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
                
                else if (Operators.IsX(input[i].ToString()))
                {
                    output += Operators.XSymbol + " ";

                    lastNoteIsOperator = false;
                }
                
                else
                {
                    complexityOperator += input[i];

                    if (Operators.IsOperator(complexityOperator))
                    {
                        operStack.Push(complexityOperator);
                        complexityOperator = "";

                        lastNoteIsOperator = true;
                    }
                }
            }
            
            while (operStack.Count > 0)
                output += operStack.Pop() + " ";
            return output;
        }

        public static double Calculate(string input)
        {
            return CalculatePolishNotation(FromString(input));
        }

        private static double CalculatePolishNotation(string notation)
        {            
            char[] separator = { ' ' };

            List<string> polishNotationList = new List<string>(notation.
                Split(separator, StringSplitOptions.RemoveEmptyEntries));

            Stack<IOperator> operatorsStack = new Stack<IOperator>();
            IOperator firstOperator = null;

            foreach (string notationElement in polishNotationList)
            {
                if (Operators.IsOperator(notationElement))
                {
                    IOperator opert = Operators.GetOperator(notationElement);

                    if (Operators.IsUnaryOperator(opert))
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
                else if (Operators.IsX(notationElement))
                {
                    operatorsStack.Push(new Operannd_X());
                }
                else
                {
                    operatorsStack.Push(new Operand_Value(double.Parse(notationElement)));
                }
            }

            firstOperator = operatorsStack.Pop();

            var function = new Function(firstOperator);
            return function.Execute(0f);
        }

        static private bool IsDelimeter(string symbol)
        {
            if ((" =".IndexOf(symbol) != -1))
                return true;
            return false;
        }

        static private bool IsOperator(string symbol)
        {
            if (Operators.ListSymbols.Contains(symbol))
                return true;
            return false;
        }

        static private int GetPriority(string symbol)
        {
            if (Operators.ListSymbols.Contains(symbol))
                return Operators.ListSymbols.IndexOf(symbol);
            else
                return Operators.ListSymbols.Count;
        }
    }
}

