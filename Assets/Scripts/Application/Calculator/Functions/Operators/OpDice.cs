using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator.Operators
{
    public class OpDice : DefaultOperator
    {
        public OpDice() : base(null, null)
        {
        }

        public OpDice(IOperator diceCount, IOperator countFaces) : base(diceCount, countFaces)
        {
        }

        public override double GetValue()
        {
            int max = (int)_rightOperand.GetValue() + 1;
            int sum = 0;
            for(int i = 0; i < _leftOperand.GetValue(); i++)
                sum += Random.Range(1, max);
            
            return sum;
        }

        public override string Symbol => "d";
    }
}

