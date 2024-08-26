using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class JugadorFracciones : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private float direccionY;
    private float direccionX;
    private Vector2 direccion;
    private int resultadoCorrecto;
    public Fraccion fraccionInicial;
    private VidaController vidaController;
    private int colisionesIncorrectas = 0;

    private int respuestasCorrectas = 0;
    private int totalRespuestasNecesarias = 2;
    public TextMeshProUGUI contadorRespuestasText;
    public AudioClip sonidoCorrecto;
    public AudioClip sonidoIncorrecto;
    void Start()
    {
        vidaController = FindObjectOfType<VidaController>();
        if (vidaController == null)
        {
            Debug.LogError("No se encontró el componente VidaController.");
        }
    }

    private void AumentarRespuestaCorrecta()
    {
        respuestasCorrectas++;
        Debug.Log("Respuestas correctas: " + respuestasCorrectas);
        contadorRespuestasText.text = $"{respuestasCorrectas}/{totalRespuestasNecesarias}";
        if (respuestasCorrectas >= totalRespuestasNecesarias)
        {
            SceneManager.LoadScene(23);
        }
    }
    void Update()
    {
        direccionY = Input.GetAxisRaw("Vertical");
        direccionX = Input.GetAxisRaw("Horizontal");
        direccion = new Vector2(direccionX, direccionY).normalized;
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(direccion.x * speed, direccion.y * speed);
        rb.position = new Vector2(Mathf.Clamp(rb.position.x, -11.0f, 11.0f), Mathf.Clamp(rb.position.y, -4.45f, 4.38f));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fraccion"))
        {
            FraccionBar fraccionBarra = other.GetComponent<FraccionBar>();
            if (fraccionBarra != null)
            {
                Contenedor contenedor = FindObjectOfType<Contenedor>();
                Fraccion fraccionInicial = contenedor.ObtenerFraccionInicial();
                Fraccion fraccionColisionada = fraccionBarra.fraccion;
                Debug.Log($"Fracción inicial OnTriggerEnter: {fraccionInicial.numerador}/{fraccionInicial.denominador}");
                Debug.Log($"Colisión con la fracción de barra: {fraccionColisionada.numerador}/{fraccionColisionada.denominador}");

                bool sonEquivalentes = SonFraccionesEquivalentes(fraccionInicial, fraccionColisionada);
                if (sonEquivalentes)
                {
                    AudioSource.PlayClipAtPoint(sonidoCorrecto, transform.position);
                    AumentarRespuestaCorrecta();
                    contenedor.GenerarFraccionAleatoria();

                }
                else
                {
                    colisionesIncorrectas++;
                    if (colisionesIncorrectas >= 2)
                    {
                        colisionesIncorrectas = 0;
                        AudioSource.PlayClipAtPoint(sonidoIncorrecto, transform.position);
                        vidaController.RespuestaIncorrecta();
                    }
                    contenedor.GenerarFraccionAleatoria();
                }
            }
            else
            {
                Debug.LogError("No se pudo obtener el componente FraccionBar.");

            }
        }
    }
    private bool SonFraccionesEquivalentes(Fraccion fraccionInicial, Fraccion fraccionColisionada)
    {
        return fraccionInicial.numerador == fraccionColisionada.numerador && fraccionInicial.denominador == fraccionColisionada.denominador;
    }
}
