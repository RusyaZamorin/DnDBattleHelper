using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator.Functions
{
    public class Function
    {
        private IOperator _funcOperator;

        public Function(IOperator funcOperator) => _funcOperator = funcOperator;        

        public double Execute(double x)
        {
            _funcOperator.SetX(x);
            return _funcOperator.GetValue();
        }

    }
}

