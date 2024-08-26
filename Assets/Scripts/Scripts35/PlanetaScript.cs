using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlanetaScript : MonoBehaviour
{
    private int resultado;
    private TextMesh textoResultado;
    public GeneradorPlanetas generador;
    private int valor;
    private void Awake()
    {
        generador = FindObjectOfType<GeneradorPlanetas>();
    }

    public void EstablecerResultado(int nuevoResultado)
    {
        resultado = nuevoResultado;
        ConfigurarValoresTexto();
    }

    private void ConfigurarValoresTexto()
    {
        if (textoResultado != null)
        {
            int valorPlaneta = Random.Range(1, 11) * resultado;
            valorPlaneta = Mathf.Min(valorPlaneta, resultado * 6);

            textoResultado.text = valorPlaneta.ToString();
        }
    }

    public int ObtenerValorDelPlaneta()
    {
        if (textoResultado != null)
        {
            return int.Parse(textoResultado.text);
        }
        else
        {
            return valor;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Nave"))
        {
            int valorPlaneta = ObtenerValorDelPlaneta();
            GeneradorPlanetas gameManager = GameObject.FindObjectOfType<GeneradorPlanetas>();
            gameManager.ColisionConPlaneta(valorPlaneta);
            Destroy(gameObject);
        }
    }
    public void EstablecerValor(int nuevoValor)
    {
        valor = nuevoValor;
    }
}
