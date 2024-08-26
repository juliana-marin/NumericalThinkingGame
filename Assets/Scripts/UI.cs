using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI problemText;
    public TextMeshProUGUI[] answersTexts; 
    public TextMeshProUGUI endText;  
    public TextMeshProUGUI contadorNumeros;
    private int cantTotalElements;
    private int cont;
    private int resultadoSustraccion;
    public static UI instance;
    private float result, firstNumber, secondNumber;
    private string operacionText, operacion;
    private GameManager gameManager;
    private string[] abreviationUnits = new string[] {"km","hm","dam","m","dm","cm","mm"};
    private float timeToResetText= 4.0f;

   public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Awake ()
    {
        instance = this;
    }
    public void SetProblemText (MathsOperations maths)
    {
        string operatorText = "";
        string abreviatura= maths.activeUnits ? abreviationUnits[Random.Range(0,8)] : "";
        int numCorrectPanel = Random.Range(0,3);
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
            if(index == numCorrectPanel)
            {
                maths.setCorrectPanel(numCorrectPanel);
                answersTexts[index].text = result.ToString() + abreviatura;
            }else
            answersTexts[index].text = Random.Range(0,100).ToString() + abreviatura;
        }
    }
    public void SetLengthUnitsText (LengthUnits units, string[]words)
    {
        int numCorrectPanel = Random.Range(0,3);
        for(int index = 0; index < answersTexts.Length; ++ index)
        {
            int num = Random.Range(0, words.Length);
            if(index == numCorrectPanel)
            {
                units.setCorrectPanel(numCorrectPanel);
                answersTexts[index].text = units.lengthUnits.ToString();
            }else
            answersTexts[index].text = words[num].ToString();
        }
    }
    public void SetContElementsText (Objects objects)
    {
        cantTotalElements = Random.Range(objects.elementsMin, objects.elementsMax + 1);
        operacion = objects.operacion.ToString();

        if(objects.items_2.ToString() == "Ninguno" && objects.operacion.ToString() == "Ninguno")
        {
            problemText.text = "Cuenta las " + objects.items_1.ToString();
            ObjectsController.instance.GenerarObjetos(objects.items_1, cantTotalElements); 
        }
        
        if(objects.items_2.ToString() != "Ninguno" && objects.operacion.ToString() == "Adicion")
        {
            SetAddElementsText(objects);
        }
        if(objects.items_2.ToString() == "Ninguno" && objects.operacion.ToString() == "Sustraccion")
        {
            SetSustracElementsText(objects);
        }
    }
    public void SetAddElementsText (Objects objects)
    {   
        int cantItems1 = cantTotalElements/2;
        int cantItems2 = cantTotalElements - cantItems1;
        problemText.text = "Consigue " + cantItems1 + " " + objects.items_1.ToString() + " y " + cantItems2 + " " + objects.items_2.ToString();
        ObjectsController.instance.GenerarObjetos(objects.items_1, cantItems1);     
        ObjectsController.instance.GenerarObjetos(objects.items_2, cantItems2);     

    }
    public void SetSustracElementsText (Objects objects)
    {
        int cantItems = Random.Range(objects.elementsMin, cantTotalElements);
        problemText.text = "Tengo " + cantTotalElements + " " + objects.items_1.ToString() + " y le quito " + cantItems +" cuantas me quedan";
        resultadoSustraccion = cantTotalElements - cantItems;
        cont = cantTotalElements - 1;
        ObjectsController.instance.GenerarObjetos(objects.items_1, cantItems);    
    } 
    
    public void SetContador()
    {
        cont++;
          
        contadorNumeros.text = cont.ToString();
        if(cont >= cantTotalElements)
        {
            GameManager.instance.CorrectAnswer();
        }
    }

    public void SetContadorSustracction()
    {
        if (cont < 0) return;
        contadorNumeros.text = cont.ToString();

        if(cont == resultadoSustraccion)
        {
            ResetContador();
            GameManager.instance.CorrectAnswer();
            GameManager.instance.completeSustraccion();
        }else{
            cont--;
        }
    }
    private void ResetContador()
    {
        cont = 0;
        contadorNumeros.text = "";
    }

    public void setOperacion(string operacion){
        this.operacion = operacion;
    }
    public string getOperacion(){
        return operacion;
    }
}
