using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application.CoreEntities;
using Calculator;
using Calculator.Operators;

public class Starter : MonoBehaviour
{    
    public string input;
    public Function f2;
    private void Awake()
    {
        Function f = new Function(new OpDice(new Operand_Value(2), new Operand_Value(6)));
        f2 = f.Copy();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("input = " + CharacteristicsCalculator.CalculateInputToInt(input));
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log(f2.Calculate());
        }
    }
}
