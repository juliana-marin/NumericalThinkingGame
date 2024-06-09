using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int score = 0;

    public Text scoreText;

    private void Awake()
    {
        // Asegurarse de que sólo hay una instancia de ScoreManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText();
    }

    // Método para añadir puntos al score
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    // Métodos para eventos específicos
    public void QuestionAnsweredCorrectly()
    {
        AddScore(20); // Puntos por cada pregunta correcta
    }

    public void FruitCollected()
    {
        AddScore(5); // Puntos por cada fruta recolectada
    }

    public void EnemyDefeated()
    {
        AddScore(10); // Puntos por cada enemigo exterminado
    }
}

