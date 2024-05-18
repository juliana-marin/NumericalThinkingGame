using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class GeneradorDivisiones : MonoBehaviour
{
    public GameObject prefabPlaneta;
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
         // Generar dividendo y divisor aleatorios
        divisor = Random.Range(2, 11);
         // Generar un dividendo que sea múltiplo del divisor
         maxDividendo = 100 / divisor; // Evitar que el dividendo sea mayor que 100
        dividendo = divisor * Random.Range(1, maxDividendo + 1);
        
        // Calcular el resultado correcto
        resultadoDivision = dividendo / divisor;

        // Mostrar la division en pantalla
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
   



   

   public void CrearPlaneta( int valor = -1)
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







    // Asignar el valor del planeta al GeneradorDivisiones
    planetaDivision.generador = this;


 // Lista de valores posibles, incluyendo el resultado correcto
    List<int> valoresPosibles = new List<int>();

   


 // Cálculo del rango de valores posibles alrededor del resultado
    int rango = 3; // Puedes ajustar este valor según la dificultad deseada
    int valorResultado = resultadoDivision;
    int valorMinimo = Mathf.Max(1, valorResultado - rango);
    int valorMaximo = Mathf.Min(100, valorResultado + rango);

   
    // Generar otros valores aleatorios para completar la lista
    while (valoresPosibles.Count < 4)
    {
         valor = Random.Range(valorMinimo, valorMaximo + 1);
        if (!valoresPosibles.Contains(valor))
        {
            valoresPosibles.Add(valor);
        }
    }

    // Barajar la lista para que el resultado correcto no esté siempre en la misma posición
    valoresPosibles = valoresPosibles.OrderBy(x => Random.value).ToList();

    // Establecer los valores en los textos de los planetas
    for (int i = 0; i < valoresPosibles.Count; i++)
    {

   

Debug.Log($"Valor asignado al planeta: {valor}");


    planetaDivision.EstablecerValor(valor);


    // Agregar un objeto de texto como hijo del planeta
        GameObject textoObjeto = new GameObject("TextoResultado");
        textoObjeto.transform.parent = nuevoPlanet.transform;
        TextMesh textoResultado = textoObjeto.AddComponent<TextMesh>();

        // Ajustar la posición y configuración del TextMesh
        textoResultado.characterSize = 0.15f;
        textoResultado.fontSize = 40;
        textoObjeto.transform.localPosition = new Vector3(2f, 2f, 0f);
        textoResultado.text = valor.ToString();  // Asignar el valor al texto
    }   
    // Agregar una fuerza aleatoria para que los planetas se muevan
    Rigidbody2D rb = nuevoPlanet.GetComponent<Rigidbody2D>();
    if (rb == null)
    {
        rb = nuevoPlanet.AddComponent<Rigidbody2D>();
    }
    rb.gravityScale = 0;
    rb.velocity = new Vector2(-1f, 0f); // Establecer la velocidad inicial
    rb.AddForce(Vector2.left * Random.Range(10f, 20f)); // Puedes ajustar la fuerza según sea necesario

    
        
}

   
     public void GenerarNuevaDivision()
    { 
     divisor = Random.Range(2, 11); // Generar un divisor entre 2 y 10

    // Generar un dividendo que sea múltiplo del divisor
     maxDividendo = 100 / divisor; // Evitar que el dividendo sea mayor que 100
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
             divisor = Random.Range(2, 11); // Generar un divisor entre 2 y 10

    // Generar un dividendo que sea múltiplo del divisor
             maxDividendo = 100 / divisor; // Evitar que el dividendo sea mayor que 100
             dividendo = divisor * Random.Range(1, maxDividendo + 1);
            resultadoDivision = dividendo / divisor;
            // Actualizar el texto en la pantalla con la nueva division
        textoDivision.text = $"{dividendo} ÷ {divisor} = ?";

             

             RespuestaCorrecta();
            // Generar los planetas nuevamente
            CrearPlaneta();
        }else{
         Debug.Log("Incorrect planet");
AudioSource.PlayClipAtPoint(sonidoIncorrecto, transform.position, 0.5f);
          colisionesIncorrectas++;

        if (colisionesIncorrectas >= 2)
        {
            colisionesIncorrectas = 0; // Reiniciar el contador
            //RespuestaIncorrecta();
            vidaController.RespuestaIncorrecta();
        }



          
        
        }
        
        // Imprimir información en consola
        Debug.Log("Colisión con planeta de valor " + valorPlaneta + ". Resultado actual: " + resultadoDivision);
    }



    public void RespuestaCorrecta()
    {
        respuestasCorrectas++;
        ActualizarTextoContador();

        if (respuestasCorrectas >= totalRespuestasNecesarias)
        {
            SceneManager.LoadScene(22);

            // Aquí puedes llamar a un método para avanzar al siguiente nivel
            // Por ejemplo, SceneManager.LoadScene("SiguienteNivel");
        }
    }

    void ActualizarTextoContador()
    {
        textoContador.text = $"{respuestasCorrectas}/{totalRespuestasNecesarias}";
    }

}







