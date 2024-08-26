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
    public GameObject gameOver;

    void Start()
    {
        
    }
    void ActualizarBarraVida()
    {
        float porcentajeVida = vidaActual / vidaMaxima;
        barraVida.fillAmount = porcentajeVida;
    }


    public void RespuestaIncorrecta()
    {
        vidaActual -= cantidadDeDisminucion;
        vidaActual = Mathf.Clamp(vidaActual, 0f, vidaMaxima);
        ActualizarBarraVida();

        if (vidaActual <= 0f)
        {
            Debug.Log("Mostrando pantalla de Game Over");
            Time.timeScale = 0f;
            Debug.Log("¡Fin del juego! Has perdido.");
            gameOver.SetActive(true);
        }

    }
    public void DisminuirVida(float cantidad)
    {
        vidaActual -= cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0f, vidaMaxima);
        ActualizarBarraVida();

        if (vidaActual <= 0f)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}
