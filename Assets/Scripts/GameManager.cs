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
    public static GameManager instance;
    public string[] words;
    
    private int correctPanel;
    public void Awake()
    {
        instance = this;
    }

    public void Start(){
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
        else
            IncorrectAnswer();
    }

    public void getGameObject(){
        if(problems.Length != 0 ){
            correctPanel = problems[curProblem].getCorrectPanel();
            
        }
        if(unitsLength.Length !=0){
            correctPanel = unitsLength[curProblem].getCorrectPanel();
        }
        
    }
    
    public void CorrectAnswer()
    {
        UI.instance.SetEndText(true,"correcto!");
       //si es el ultimo problema llama a win, sino inserte mas problemas
        if(problems.Length - 1 == curProblem|| unitsLength.Length - 1 == curProblem)
            Win();
        else
            SetProblem(curProblem + 1);
    }

    public void IncorrectAnswer()
    {
        UI.instance.SetEndText(false,"Error!");
        //Lose();

    }

    public void SetProblem(int problem)
    {
        curProblem = problem;
        if(problems.Length != 0){
            UI.instance.SetProblemText(problems[curProblem]);
        }
        if(unitsLength.Length !=0){
            UI.instance.SetLengthUnitsText(unitsLength[curProblem], words);
        }
        
    }

    public void Win()
    {   
        changeLevel.nextLevel = true;
        changeLevel.idLevel = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("changeLevel.idLevel--------" + changeLevel.idLevel);
        Debug.Log("changeLevel.nextLevel--------" + changeLevel.idLevel);
        UI.instance.SetEndText(true, "Ganaste!");
    }

    public void Lose()
    {
        UI.instance.SetEndText(false, "Fin del Juego!");
    }
}
