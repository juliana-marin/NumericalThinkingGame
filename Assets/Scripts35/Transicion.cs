using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transicion : MonoBehaviour
{
     public float tiempoDeEspera = 2f; // Tiempo de espera antes de cargar la siguiente escena
    public GameObject winnerImage; // Referencia a la imagen de ganador en la escena

private bool showWinner;



    private void Start()
    {

         showWinner = false;


        // Después de un tiempo de espera, cargar la siguiente escena
        Invoke("CargarSiguienteEscena", tiempoDeEspera);
    }

    private IEnumerator CargarSiguienteEscena()
    {
          Debug.Log("Iniciando carga de siguiente escena.");
        yield return new WaitForSeconds(3f); // Tiempo de espera antes de cargar la siguiente escena

        // Cargar la siguiente escena
        SceneManager.LoadScene("SceneDivision");
    }

    public void MostrarWinner()
    {
        showWinner = true;
    }

    


private void Update()
    {
        if (showWinner)
        {
            // Lógica para mostrar la imagen de "winner"
            winnerImage.SetActive(true);

            // Lógica para cargar la siguiente escena después de un tiempo
            StartCoroutine(CargarSiguienteEscena());
        }
    }



}
