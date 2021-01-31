using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacteristicsCalculator.Operators
{
    public class OperandX : BaseOperator
    {
        public const string SymbolX = "x";

        private double _valueX;

        public OperandX() : base(null, null) { }

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

