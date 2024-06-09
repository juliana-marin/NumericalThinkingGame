using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LengthUnits
{ 
    public Units lengthUnits;
    // Es el numero del indice de la respuesta correcta en la matriz de respuestas
    private int correctPanel;
    public void setCorrectPanel(int correctPanel){
        this.correctPanel = correctPanel;
    }
    public int getCorrectPanel(){
        return correctPanel;
    }

}


public enum Units
{
    Kilometro,
    Hectometro,
    Decametro,
    Decimetro,
    Centimetro,
    Milimetro
}

