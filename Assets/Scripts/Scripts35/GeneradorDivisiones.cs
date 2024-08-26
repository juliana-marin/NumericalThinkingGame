using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class GeneradorDivisiones : MonoBehaviour
{
    public GameObject prefabPlaneta;
    public GameObject nivelCompletado;
    public TextMeshProUGUI textoDivision;
    private int resultadoCorrecto;
    private int dividendo;
    private int divisor;
    private int maxDividendo;
    private int resultadoDivision;
    public TextMeshProUGUI textoContador;
    private int respuestasCorrectas = 0;
    private int totalRespuestasNecesarias = 3;
    public VidaController vidaController;
    private int colisionesIncorrectas = 0;
    public AudioClip sonidoCorrecto;
    public AudioClip sonidoIncorrecto;
    private void Start()
    {
        divisor = Random.Range(2, 11);
        maxDividendo = 100 / divisor;
        dividendo = divisor * Random.Range(1, maxDividendo + 1);
        resultadoDivision = dividendo / divisor;
        textoDivision.text = $"{dividendo} ÷ {divisor} = ?";
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
        GameObject nuevoPlanet = Instantiate(prefabPlaneta, new Vector3(12f, randomY, 0f), Quaternion.identity);
        if (nuevoPlanet == null)
        {
            Debug.LogError("nuevoPlanet es null");
        }
        PlanetaDivision planetaDivision = nuevoPlanet.GetComponent<PlanetaDivision>();

        if (planetaDivision == null)
        {
            Debug.LogError("planetaDivision es null");
        }
        planetaDivision.generador = this;
        List<int> valoresPosibles = new List<int>();
        int rango = 3;
        int valorResultado = resultadoDivision;
        int valorMinimo = Mathf.Max(1, valorResultado - rango);
        int valorMaximo = Mathf.Min(100, valorResultado + rango);

        while (valoresPosibles.Count < 4)
        {
            valor = Random.Range(valorMinimo, valorMaximo + 1);
            if (!valoresPosibles.Contains(valor))
            {
                valoresPosibles.Add(valor);
            }
        }

        valoresPosibles = valoresPosibles.OrderBy(x => Random.value).ToList();

        for (int i = 0; i < valoresPosibles.Count; i++)
        {
            Debug.Log($"Valor asignado al planeta: {valor}");
            planetaDivision.EstablecerValor(valor);
            GameObject textoObjeto = new GameObject("TextoResultado");
            textoObjeto.transform.parent = nuevoPlanet.transform;
            TextMesh textoResultado = textoObjeto.AddComponent<TextMesh>();


            textoResultado.characterSize = 0.15f;
            textoResultado.fontSize = 40;
            textoObjeto.transform.localPosition = new Vector3(2f, 2f, 0f);
            textoResultado.text = valor.ToString();
        }
        Rigidbody2D rb = nuevoPlanet.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = nuevoPlanet.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = 0;
        rb.velocity = new Vector2(-1f, 0f);
        rb.AddForce(Vector2.left * Random.Range(10f, 20f));
    }

    public void GenerarNuevaDivision()
    {
        divisor = Random.Range(2, 11);
        maxDividendo = 100 / divisor;
        resultadoCorrecto = divisor * Random.Range(1, maxDividendo + 1);

        textoDivision.text = $"{dividendo} ÷ {Random.Range(2, 10)} = ?";
        CrearPlaneta();
    }
    public int ObtenerResultadoDivision()
    {
        return resultadoDivision;
    }

    public void ColisionConPlaneta(int valorPlaneta)
    {
        Debug.Log($"División propuesta: {dividendo} / {divisor} = ?");
        Debug.Log($"Respuesta correcta: {resultadoDivision}");
        Debug.Log($"Valor del planeta colisionado: {valorPlaneta}");


        if (valorPlaneta == resultadoDivision)
        {
            Debug.Log("Correct planet");
            AudioSource.PlayClipAtPoint(sonidoCorrecto, transform.position, 0.5f);
            divisor = Random.Range(2, 11);
            maxDividendo = 100 / divisor;
            dividendo = divisor * Random.Range(1, maxDividendo + 1);
            resultadoDivision = dividendo / divisor;
            textoDivision.text = $"{dividendo} ÷ {divisor} = ?";
            RespuestaCorrecta();
            CrearPlaneta();
        }
        else
        {
            Debug.Log("Incorrect planet");
            AudioSource.PlayClipAtPoint(sonidoIncorrecto, transform.position, 0.5f);
            colisionesIncorrectas++;
            if (colisionesIncorrectas >= 2)
            {
                colisionesIncorrectas = 0;
                vidaController.RespuestaIncorrecta();
            }
        }

        Debug.Log("Colisión con planeta de valor " + valorPlaneta + ". Resultado actual: " + resultadoDivision);
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

}







