using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject nivelCompletado;
    public Renderer background;
    public PlayerController player;
    public int curProblem;  
    public AudioClip sonidoCorrecto;
    public AudioClip sonidoIncorrecto;
    [SerializeField] private ParticleSystem particle;
    public TextMeshProUGUI endText;  
    public MathsOperations[] problems;
    public LengthUnits[] unitsLength;
    public string[] words;
    public Objects[] objects;
    public static GameManager instance;
    private int correctPanel;
    private float timeToResetText= 4.0f;
        
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
        if(problems.Length - 1 == curProblem|| unitsLength.Length - 1 == curProblem || objects.Length -1  == curProblem)
        {
            Win();
        }else{
            AudioSource.PlayClipAtPoint(sonidoCorrecto, transform.position, 0.7f);
            SetProblem(curProblem + 1);
        }
    }
    public void Win()
    {   
        SetEndText(true,"Muy Bien!!");
        particle.Play();
        AudioSource.PlayClipAtPoint(sonidoCorrecto, transform.position, 0.7f);
        Invoke("ShowNivelCompletado", 3f);
        
    }

    public void completeSustraccion()
    {   
        SetEndText(true,"Muy Bien!!");
        particle.Play();
        AudioSource.PlayClipAtPoint(sonidoCorrecto, transform.position, 0.7f);
    }

    public void SetEndText (bool win, string msj)
    {
        endText.gameObject.SetActive(true);

        if(win)
        {
            endText.text = msj;
        }else{
            endText.text = msj;
        }
        Invoke("ResetText", timeToResetText);

    }
    public void ResetText()
    {
        endText.enabled = false;
    }
    public void ShowNivelCompletado()
    {
        nivelCompletado.gameObject.SetActive(true);
    }
    public void IncorrectAnswer()
    {
        AudioSource.PlayClipAtPoint(sonidoIncorrecto, transform.position, 0.7f);
    }
    
    /*public void Lose()
    {
        UI.instance.SetEndText(false, "Fin del Juego!");
    }*/

}
