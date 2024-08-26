using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;
public class GeneradorPlanetas : MonoBehaviour
{   
    public GameObject nivelCompletado;
    public GameObject prefabPlaneta;
    public TextMeshProUGUI textoMultiplicacion;
    private int resultadoCorrecto;
    private int multiplicador;
    private int multiplicando;
    private int resultadoMultiplicacion;
    public TextMeshProUGUI textoContador;
    private int respuestasCorrectas = 0;
    private int totalRespuestasNecesarias = 2;
    public VidaController vidaController;
    private int colisionesIncorrectas = 0;
    public AudioClip sonidoCorrecto;
    public AudioClip sonidoIncorrecto;
    private void Start()
    {
        StartCoroutine(ReproducirInstrucciones());
        multiplicador = Random.Range(2, 11);
        multiplicando = Random.Range(2, 11);
        resultadoMultiplicacion = multiplicador * multiplicando;
        textoMultiplicacion.text = $"{multiplicador} x {multiplicando} = ?";
        StartCoroutine(GenerarPlanetas());
        ActualizarTextoContador();
    }
    private IEnumerator GenerarPlanetas()
    {
        while (true)
        {
            CrearPlaneta();
            yield return new WaitForSeconds(3f);
        }
    }
    public void CrearPlaneta(int valor = -1)
    {
        float randomY = Random.Range(-4.25f, 4.25f);
        GameObject nuevoPlaneta = Instantiate(prefabPlaneta, new Vector3(12f, randomY, 0f), Quaternion.identity);
        PlanetaScript planetaScript = nuevoPlaneta.GetComponent<PlanetaScript>();
        planetaScript.generador = this;

        if (valor == -1)
        {
            valor = Random.Range(1, 11) * multiplicador;
            valor = Mathf.Min(valor, multiplicador * 10);
            planetaScript.EstablecerValor(valor);
        }
        planetaScript.EstablecerValor(valor);
        GameObject textoObjeto = new GameObject("TextoResultado");
        textoObjeto.transform.parent = nuevoPlaneta.transform;
        TextMesh textoResultado = textoObjeto.AddComponent<TextMesh>();

        textoResultado.characterSize = 0.1f;
        textoResultado.fontSize = 40;
        textoObjeto.transform.localPosition = new Vector3(0f, 0f, 0f);
        textoResultado.text = valor.ToString();

        Rigidbody2D rb = nuevoPlaneta.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = nuevoPlaneta.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = 0;
        rb.velocity = new Vector2(-1f, 0f);
        rb.AddForce(Vector2.left * Random.Range(10f, 20f));
    }
    public void GenerarNuevaMultiplicacion()
    {
        multiplicador = Random.Range(2, 10);
        resultadoCorrecto = Random.Range(1, 11) * multiplicador;

        textoMultiplicacion.text = $"{multiplicador} x {Random.Range(2, 10)} = ?";
        CrearPlaneta();
    }
    public int ObtenerResultadoMultiplicacion()
    {
        return resultadoMultiplicacion;
    }
    public void ColisionConPlaneta(int valorPlaneta)
    {
        if (valorPlaneta == resultadoMultiplicacion)
        {
            Debug.Log("Correct planet");
            AudioSource.PlayClipAtPoint(sonidoCorrecto, transform.position, 16f);
            multiplicando = Random.Range(2, 11);
            multiplicador = Random.Range(2, 11);
            resultadoMultiplicacion = multiplicando * multiplicador;
            textoMultiplicacion.text = $"{multiplicador} x {multiplicando} = ?";
            RespuestaCorrecta();
            CrearPlaneta();
        }
        else
        {
            Debug.Log("Incorrect planet");
            AudioSource.PlayClipAtPoint(sonidoIncorrecto, transform.position, 16f);
            colisionesIncorrectas++;

            if (colisionesIncorrectas >= 2)
            {
                colisionesIncorrectas = 0;
                vidaController.RespuestaIncorrecta();
            }
        }
        Debug.Log("Colisión con planeta de valor " + valorPlaneta + ". Resultado actual: " + resultadoMultiplicacion);
    }



    public void RespuestaCorrecta()
    {
        respuestasCorrectas++;
        ActualizarTextoContador();

        if (respuestasCorrectas >= totalRespuestasNecesarias)
        {
            nivelCompletado.gameObject.SetActive(true);

        }
    }
    void ActualizarTextoContador()
    {
        textoContador.text = $"{respuestasCorrectas}/{totalRespuestasNecesarias}";
    }
    IEnumerator ReproducirInstrucciones()
    {
        Time.timeScale = 0f;
        AudioSource audioSource = GameObject.Find("Instrucciones").GetComponent<AudioSource>();
        audioSource.Play();
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        Time.timeScale = 1f;
    }
}









