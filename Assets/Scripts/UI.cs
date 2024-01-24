using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI problemText;
    public TextMeshProUGUI[] answersTexts; 
    public TextMeshProUGUI endText;  
    public static UI instance;
    private float result, firstNumber, secondNumber;
    private string operacionText;

    private string[] abreviationUnits = new string[] {"km","hm","dam","m","dm","cm","mm"};
   
    void Awake ()
    {
        instance = this;
    }

    public void SetProblemText (MathsOperations maths)
    {
        string operatorText = "";
        string abreviatura= maths.activeUnits ? abreviationUnits[Random.Range(0,8)] : "";
        int numCorrectPanel = Random.Range(0,4);
        firstNumber = Random.Range(10,100);
        secondNumber = Random.Range(1,10);
        
        switch(maths.operators)
        {
            case Operations.Suma: operatorText = " + "; 
                result = firstNumber + secondNumber;
                operacionText = firstNumber + abreviatura + operatorText + secondNumber + abreviatura;
            break;
            case Operations.Resta: operatorText = " - "; 
                result = firstNumber - secondNumber;
                operacionText = firstNumber + abreviatura + operatorText + secondNumber + abreviatura;
            break;
            case Operations.Multiplicacion: operatorText = " x "; 
                result = firstNumber * secondNumber;
                operacionText = firstNumber + abreviatura + operatorText + secondNumber + abreviatura;
            break;
            case Operations.Division: operatorText = " / "; 
                result = firstNumber + secondNumber;
                operacionText = firstNumber + abreviatura + operatorText + secondNumber + abreviatura;
            break;
        }
      
        problemText.text = operacionText;

        for(int index = 0; index < answersTexts.Length; ++ index)
        {
            if(index == numCorrectPanel){
                maths.setCorrectPanel(numCorrectPanel);

                answersTexts[index].text = result.ToString() + abreviatura;
            }else
            answersTexts[index].text = Random.Range(0,100).ToString() + abreviatura;
        }
    }

    public void SetLengthUnitsText (LengthUnits units, string[]words)
    {
        int numCorrectPanel = Random.Range(0,4);
        for(int index = 0; index < answersTexts.Length; ++ index)
        {
            int num = Random.Range(0, words.Length);
            if(index == numCorrectPanel){
                units.setCorrectPanel(numCorrectPanel);
                Debug.Log("units.lengthUnits.ToString();"+ units.lengthUnits.ToString());
                answersTexts[index].text = units.lengthUnits.ToString();
            }else
            answersTexts[index].text = words[num].ToString();
        }
    }

    public void SetEndText (bool win, string msj)
    {
        endText.gameObject.SetActive(true);

        if (win)
        {
            endText.text = msj;
            endText.color = Color.green;
        }
        
        else
        {
            endText.text = msj;
            endText.color = Color.red;
        }
    }

}
