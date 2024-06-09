using System;

[System.Serializable]
public class QuestionData
{
    public string question;
    public string correctAnswer;
    public string incorrectAnswer1;
    public string incorrectAnswer2;


    public QuestionData(string q, string correct, string incorrect1, String incorrect2)
    {
        question = q;
        correctAnswer = correct;
        incorrectAnswer1 = incorrect1;
        incorrectAnswer2 = incorrect2;
  }
}

