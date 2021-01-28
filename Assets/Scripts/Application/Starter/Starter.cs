using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application.CoreEntities;
using Calculator;

public class Starter : MonoBehaviour
{    
    public string input;
    private void Awake()
    {      
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("input = " + CharacteristicsCalculator.CalculateInputToInt(input));
        }
    }
}
