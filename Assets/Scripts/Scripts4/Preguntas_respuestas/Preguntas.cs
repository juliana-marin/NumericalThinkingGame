using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class preguntas : MonoBehaviour
{
    public TextAsset csvFile;
    private char csvSeparator = ';';

    private List<string[]> questionData = new List<string[]>();
    private List<QuestionData> questionList = new List<QuestionData>();

    void Start()
    {
        LoadCSV();
        ProcessData();
    }

    public void LoadCSV()
    {
        string[] lines = csvFile.text.Split('\n');
        foreach (string line in lines)
        {
            string[] data = line.Split(csvSeparator);
            string prueba = data[0];
            if (data.Length >= 2)
            {
                string question = data[0];
                string correctAnswer = data[1];
                string incorrect1 = data[2];
                string incorrect2 = data[3];

                QuestionData newQuestion = new QuestionData(question, correctAnswer, incorrect1, incorrect2);
                questionList.Add(newQuestion);
            }
            else
            {
                Debug.LogError("La fila del archivo CSV no tiene suficientes elementos: " + line);
            }
        }
    }
    void ProcessData()
    {
        foreach (string[] row in questionData)
        {
            string question = row[0];
            string correctAnswer = row[1];

            string[] incorrectAnswers = new string[row.Length - 2];
            for (int i = 0; i < incorrectAnswers.Length; i++)
            {
                incorrectAnswers[i] = row[i + 2];
            }
        }
    }
    public QuestionData GetRandomQuestion()
    {
        int randomIndex = Random.Range(0, questionList.Count);
        return questionList[randomIndex];
    }
}
