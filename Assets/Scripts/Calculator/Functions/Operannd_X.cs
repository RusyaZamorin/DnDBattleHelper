using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator.Functions
{
    public class Operannd_X : DefaultOperator
    {
        public const string XSymbol = "x";

        private double _valueX;

        public Operannd_X() : base(null, null) { }

        public override double GetValue()
        {
            return _valueX;
        }

        public override void SetX(double x)
        {
            _valueX = x;
        }

        public override string Symbol => "x";        
    }
}

