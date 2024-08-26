using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class MathsOperations 
{  
    public Operations operators;
    private int correctPanel;
    public bool activeUnits;

    public void setCorrectPanel(int correctPanel){
        this.correctPanel = correctPanel;
    }
    public int getCorrectPanel(){
        return correctPanel;
    }

}

public enum Operations
{
    Suma,
    Resta,
    Multiplicacion,
    Division
}
