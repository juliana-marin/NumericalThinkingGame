using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public Text TotalQuestions;
    public Text Respuestas;
    private int TotalQuestionsInLevel;
    public int respuestasCorrectas = 0;
    public void aumentar()
    {
        respuestasCorrectas++;
    }
    // Start is called before the first frame update
    void Start()
    {
        TotalQuestionsInLevel = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        TotalQuestions.text = TotalQuestionsInLevel.ToString();
        Respuestas.text = respuestasCorrectas.ToString();
    }
}
