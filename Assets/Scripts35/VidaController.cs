using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class VidaController : MonoBehaviour
{
    public float vidaMaxima = 100f;
    public float vidaActual;
    public float cantidadDeDisminucion = 50f;
   public Image barraVida;
   public GameObject gameOverScreen;

   void Start()
    {
        // Desactivar el objeto GameOverScreen al inicio
    //    gameOverScreen.SetActive(false);
    }
    
    

    


    void ActualizarBarraVida()
{
    float porcentajeVida = vidaActual / vidaMaxima;
    barraVida.fillAmount = porcentajeVida;
}


 public void RespuestaIncorrecta()
{
   
    // Llama a este método cada vez que haya una respuesta incorrecta
    vidaActual -= cantidadDeDisminucion;
    vidaActual = Mathf.Clamp(vidaActual, 0f, vidaMaxima); // Asegurarse de que la vida no sea menor que 0 ni mayor que la vida máxima
    ActualizarBarraVida();

    if (vidaActual <= 0f)
    {
        Debug.Log("Mostrando pantalla de Game Over");
 //       gameOverScreen.SetActive(true);
        Time.timeScale = 0f; 
        // Aquí puedes manejar la lógica para el fin del juego
        Debug.Log("¡Fin del juego! Has perdido.");
          SceneManager.LoadScene("GameOver");
    }
   
}
    public void DisminuirVida(float cantidad)
{
    vidaActual -= cantidad;
    vidaActual = Mathf.Clamp(vidaActual, 0f, vidaMaxima); // Asegurarse de que la vida no sea menor que 0 ni mayor que la vida máxima
    ActualizarBarraVida();

    if (vidaActual <= 0f)
    {
        //SDebug.Log("Mostrando pantalla de Game Over");
        // Aquí puedes mostrar la imagen de Game Over y detener el juego
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f; // Pausar el juego
    }


    // Debug.Log("¡Fin del juego! Has perdido.");
}
    
}
