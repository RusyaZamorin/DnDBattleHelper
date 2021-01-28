using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator.Operators
{
    public class Operand_Value : DefaultOperator
    {
        private double _value;

        public Operand_Value() : base(null, null)
        {
            _value = 0f;
        }

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

        public override IOperator Copy()
        {
            var copy = base.Copy();
            ((Operand_Value)copy)._value = _value;
            return copy;
        }
    }

}
