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

             // Lista de valores posibles, incluyendo el resultado correcto
        List<int> valoresPosibles = new List<int>();

        // Agregar el resultado correcto a la lista de valores posibles
        valoresPosibles.Add(resultado);

        // Generar otros valores aleatorios para completar la lista
        while (valoresPosibles.Count < 4)
        {
            int valorPosible = Random.Range(1, 11) * resultado;
            valorPosible = Mathf.Min(valorPosible, resultado * 10);
            if (!valoresPosibles.Contains(valorPosible))
            {
                valoresPosibles.Add(valorPosible);
            }
        }

        // Barajar la lista para que el resultado correcto no esté siempre en la misma posición
        valoresPosibles = valoresPosibles.OrderBy(x => Random.value).ToList();

        // Establecer los valores en los textos de los planetas
        for (int i = 0; i < valoresPosibles.Count; i++)
        {
            textoResultado.text = valoresPosibles[i].ToString();
        }



//            int valorPlaneta = Random.Range(1, 11) * resultado;
//            valorPlaneta = Mathf.Min(valorPlaneta, resultado * 6);
//            textoResultado.text = valorPlaneta.ToString();
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
        // Manejo de la situación en la que textoResultado es nulo
        // Puedes devolver un valor predeterminado o lanzar una excepción, dependiendo de la lógica de tu juego.
        return valor; // Cambia esto según tus necesidades
    }
}

//    private void OnTriggerEnter2D(Collider2D collision)
//    {

//       if (collision.CompareTag("Nave"))
//    {
//        GeneradorPlanetas generadorPlanetas = FindObjectOfType<GeneradorPlanetas>();
//        if (generadorPlanetas != null)
//        {
//            int valorPlaneta = ObtenerValorDelPlaneta();
//            int resultadoCorrecto = generadorPlanetas.ObtenerResultadoCorrecto();
//            Debug.Log($"Valor del planeta: {valorPlaneta}, Resultado correcto: {resultadoCorrecto}");

//            if (TieneResultadoCorrecto(valorPlaneta))
//            {
//                generadorPlanetas.GenerarMultiplicacion();
//            }
//            else
//            {
//                Debug.Log("Colisión con planeta incorrecto. No se cambia la multiplicación.");
//            }
//        }
//    }


//        if (collision.CompareTag("Player"))
//        {
//            GeneradorPlanetas generadorPlanetas = FindObjectOfType<GeneradorPlanetas>();
//            generadorPlanetas.ColisionConPlaneta(ObtenerValorDelPlaneta());
//             Debug.Log("Mensaje del script planeta script");

//        }
//    }






void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Nave"))
        {

             int valorPlaneta = ObtenerValorDelPlaneta();
            // Obtener el GameManager
            GeneradorDivisiones gameManager = GameObject.FindObjectOfType<GeneradorDivisiones>();

            // Notificar al GameManager sobre la colisión
            gameManager.ColisionConPlaneta(valorPlaneta);

            // Destruir el planeta
            Destroy(gameObject);
        }
    }





   public void EstablecerValor(int nuevoValor)
    {
        valor = nuevoValor;
    }
}