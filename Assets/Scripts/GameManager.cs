using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Renderer background;
    public PlayerController player;
    public ChangeLevel changeLevel;
    public int curProblem;  
    public MathsOperations[] problems;
    public LengthUnits[] unitsLength;
    public string[] words;
    public Objects[] objects;
    public static GameManager instance;
    private int correctPanel;
    private float timeToChangeLevel= 4.0f;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        SetProblem(0);
    }

    public void Update()
    {
        background.material.mainTextureOffset = background.material.mainTextureOffset + new Vector2(0.013f, 0) * Time.deltaTime;
    }

     public void OnPlayerEnterPanel(int panel)
    {
        getGameObject();
    
        if (panel == correctPanel)
            CorrectAnswer();
        else{
            IncorrectAnswer();
        }
            
    }

    public void getGameObject()
    {
        if(problems.Length != 0 ){
            correctPanel = problems[curProblem].getCorrectPanel();
            
        }
        if(unitsLength.Length !=0){
            correctPanel = unitsLength[curProblem].getCorrectPanel();
        }
        
    }
    
    public void SetProblem(int problem)
    {
        curProblem = problem;
        if(problems.Length != 0)
        {
            UI.instance.SetProblemText(problems[curProblem]);
        }
        if(unitsLength.Length !=0)
        {
            UI.instance.SetLengthUnitsText(unitsLength[curProblem], words);
        }
        if(objects.Length !=0)
        {
            UI.instance.SetContElementsText(objects[curProblem]);
        }
    }
    public void CorrectAnswer()
    {
        UI.instance.SetEndText(true,"Muy Bien!!");

        if(problems.Length - 1 == curProblem|| unitsLength.Length - 1 == curProblem || objects.Length -1  == curProblem)
        {
            Win("Ganaste!!!");
        }else{
            SetProblem(curProblem + 1);
        }
    }

    public void IncorrectAnswer()
    {
        UI.instance.SetEndText(false,"Intentalo de Nuevo");
        //Lose();
    }
    public void Win(string mjs)
    {   
        Invoke("ChangeLevel", timeToChangeLevel);
        UI.instance.SetEndText(true, mjs);
    }

    public void Lose()
    {
        UI.instance.SetEndText(false, "Fin del Juego!");
    }
    public void ChangeLevel()
    {
        changeLevel.nextLevel = true;
        changeLevel.idLevel = SceneManager.GetActiveScene().buildIndex;
    }
    public void ConteoNumeros()
    {
        Invoke("ChangeLevel", timeToChangeLevel);
        /*if(objects.Length -1  == curProblem){
            changeLevel.nextLevel = true;
            changeLevel.idLevel = SceneManager.GetActiveScene().buildIndex;
        }else{
            
            this.SetProblem(curProblem +1);
        }*/
    }

}
