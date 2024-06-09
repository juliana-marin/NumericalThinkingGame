using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;




public class GeneradorPlanetas : MonoBehaviour
{
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


         // Generar multiplicador y multiplicando aleatorios
        multiplicador = Random.Range(2, 11);
        multiplicando = Random.Range(2, 11);
        
        // Calcular el resultado correcto
        resultadoMultiplicacion = multiplicador * multiplicando;

        // Mostrar la multiplicación en pantalla
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
   



   

   public void CrearPlaneta( int valor = -1)
{
   float randomY = Random.Range(-4.25f, 4.25f);
    GameObject nuevoPlaneta = Instantiate(prefabPlaneta, new Vector3(12f, randomY, 0f), Quaternion.identity);

    PlanetaScript planetaScript = nuevoPlaneta.GetComponent<PlanetaScript>();

    // Asignar el valor del planeta al GeneradorPlanetas
    planetaScript.generador = this;

    if (valor == -1)
    {
        // Si no se proporciona un valor específico, usar la lógica aleatoria
        valor = Random.Range(1, 11) * multiplicador;
        valor = Mathf.Min(valor, multiplicador * 10);
        planetaScript.EstablecerValor(valor);
    }

    planetaScript.EstablecerValor(valor);

    // Agregar un objeto de texto como hijo del planeta
        GameObject textoObjeto = new GameObject("TextoResultado");
        textoObjeto.transform.parent = nuevoPlaneta.transform;
        TextMesh textoResultado = textoObjeto.AddComponent<TextMesh>();

        // Ajustar la posición y configuración del TextMesh
        textoResultado.characterSize = 0.1f;
        textoResultado.fontSize = 40;
        textoObjeto.transform.localPosition = new Vector3(0f, 0f, 0f);
        textoResultado.text = valor.ToString();  // Asignar el valor al texto

    // Agregar una fuerza aleatoria para que los planetas se muevan
    Rigidbody2D rb = nuevoPlaneta.GetComponent<Rigidbody2D>();
    if (rb == null)
    {
        rb = nuevoPlaneta.AddComponent<Rigidbody2D>();
    }
    rb.gravityScale = 0;
    rb.velocity = new Vector2(-1f, 0f); // Establecer la velocidad inicial
    rb.AddForce(Vector2.left * Random.Range(10f, 20f)); // Puedes ajustar la fuerza según sea necesario

    
        
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
            // Cambiar la multiplicación si el valor del planeta coincide con el resultado
            multiplicando = Random.Range(2, 11);
            multiplicador = Random.Range(2, 11);
            resultadoMultiplicacion = multiplicando * multiplicador;
            // Actualizar el texto en la pantalla con la nueva multiplicación
        textoMultiplicacion.text = $"{multiplicador} x {multiplicando} = ?";

             

             RespuestaCorrecta();
            // Generar los planetas nuevamente
            CrearPlaneta();
        }else{
         Debug.Log("Incorrect planet");
                  AudioSource.PlayClipAtPoint(sonidoIncorrecto, transform.position, 16f);
          colisionesIncorrectas++;

        if (colisionesIncorrectas >= 2)
        {
            colisionesIncorrectas = 0; // Reiniciar el contador
            //RespuestaIncorrecta();
            vidaController.RespuestaIncorrecta();
        }



          
        
        }
        // Imprimir información en consola
        Debug.Log("Colisión con planeta de valor " + valorPlaneta + ". Resultado actual: " + resultadoMultiplicacion);
    }



    public void RespuestaCorrecta()
    {
        respuestasCorrectas++;
        ActualizarTextoContador();

        if (respuestasCorrectas >= totalRespuestasNecesarias)
        {
            
    SceneManager.LoadScene(21);

           
        }
    }

    void ActualizarTextoContador()
    {
        textoContador.text = $"{respuestasCorrectas}/{totalRespuestasNecesarias}";
    }




IEnumerator ReproducirInstrucciones()
{
    // Pausar el juego
    Time.timeScale = 0f;

    AudioSource audioSource = GameObject.Find("Instrucciones").GetComponent<AudioSource>();

    // Reproducir el audio de las instrucciones
    audioSource.Play();

    // Esperar a que termine la reproducción del audio
    while (audioSource.isPlaying)
    {
        yield return null;
    }

    // Reanudar el juego
    Time.timeScale = 1f;
}

}









