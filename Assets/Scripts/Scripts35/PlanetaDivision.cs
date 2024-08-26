using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class PlanetaDivision : MonoBehaviour
{
    private int resultado;
    private TextMesh textoResultado;
    public GeneradorDivisiones generador;
    private int valor;
    private void Awake()
    {
        generador = FindObjectOfType<GeneradorDivisiones>();
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
            List<int> valoresPosibles = new List<int>();
            valoresPosibles.Add(resultado);
            while (valoresPosibles.Count < 4)
            {
                int valorPosible = Random.Range(1, 11) * resultado;
                valorPosible = Mathf.Min(valorPosible, resultado * 10);
                if (!valoresPosibles.Contains(valorPosible))
                {
                    valoresPosibles.Add(valorPosible);
                }
            }
            valoresPosibles = valoresPosibles.OrderBy(x => Random.value).ToList();
            for (int i = 0; i < valoresPosibles.Count; i++)
            {
                textoResultado.text = valoresPosibles[i].ToString();
            }
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Nave"))
        {
            int valorPlaneta = ObtenerValorDelPlaneta();
            GeneradorDivisiones gameManager = GameObject.FindObjectOfType<GeneradorDivisiones>();
            gameManager.ColisionConPlaneta(valorPlaneta);
            Destroy(gameObject);
        }
    }
    public void EstablecerValor(int nuevoValor)
    {
        valor = nuevoValor;
    }
}