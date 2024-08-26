using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transicion : MonoBehaviour
{
    public float tiempoDeEspera = 2f;
    public GameObject winnerImage;
    private bool showWinner;
    private void Start()
    {
        showWinner = false;
        Invoke("CargarSiguienteEscena", tiempoDeEspera);
    }
    private IEnumerator CargarSiguienteEscena()
    {
        Debug.Log("Iniciando carga de siguiente escena.");
        yield return new WaitForSeconds(3f);
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
            winnerImage.SetActive(true);
            StartCoroutine(CargarSiguienteEscena());
        }
    }
}
