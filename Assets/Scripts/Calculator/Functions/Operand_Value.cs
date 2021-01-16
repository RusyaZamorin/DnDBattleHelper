using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator.Functions
{
    public class Operand_Value : DefaultOperator
    {
        private double _value;

        public Operand_Value(double value) : base(null,null)
        {
            _value = value;
        }

        public override double GetValue()
        {
            return _value;
        }

        public override void SetX(double x)
        {
            return;
        }

        public override string Symbol => _value.ToString();
    }

}
