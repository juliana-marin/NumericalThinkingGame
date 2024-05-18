using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


    /*
    private int resultado;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     public void EstablecerResultado(int nuevoResultado)
    {
        resultado = nuevoResultado;
    }

    public int ObtenerResultado()
    {
        return resultado;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Nave"))
        {
            int respuestaSeleccionada = ObtenerResultado();

            if (respuestaSeleccionada == resultado)
            {
                // La respuesta es correcta, otorgar premio en puntaje
                AumentarPuntaje();
            }
            else
            {
                // La respuesta es incorrecta, estrellar la nave
                EstrellarNave();
            }
        }
    }

    void AumentarPuntaje()
    {
        // Implementa aquí la lógica para aumentar el puntaje
        Debug.Log("Respuesta correcta. Aumentar puntaje.");
        // Puedes agregar tu propia lógica para aumentar el puntaje del jugador.
    }

    void EstrellarNave()
    {
        // Implementa aquí la lógica para estrellar la nave
        Debug.Log("Respuesta incorrecta. Estrellar la nave.");
        // Puedes agregar tu propia lógica para manejar la colisión incorrecta con la nave.
    }
    





















/*
public class PlanetaScript : MonoBehaviour
{
    private int resultado;

    void Start()
    {
        // Puedes realizar configuraciones adicionales al iniciar el planeta si es necesario
    }

    public void EstablecerResultado(int nuevoResultado)
    {
        resultado = nuevoResultado;
    }

     public int ObtenerResultado()
    {
        return resultado;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GeneradorPlanetas generador = FindObjectOfType<GeneradorPlanetas>();

            if (generador != null)
            {
                // Verificar si el resultado del planeta es el correcto
                if (resultado == generador.resultadoCorrecto)
                {
                    generador.JugadorSeleccionoResultadoCorrecto();
                }
            }

            Destroy(gameObject);
        }
    }
}




//un nuevo inicio del juego

public class GeneradorPlanetas : MonoBehaviour
{
    public GameObject prefabPlaneta;
    public TextMeshProUGUI textoMultiplicacion;

    private bool mostrarMultiplicacion = true;
    private int resultadoCorrecto;

    void Start()
    {
        StartCoroutine(GenerarPlanetasContinuamente());
    }

    IEnumerator GenerarPlanetasContinuamente()
    {
        while (true)
        {
            if (mostrarMultiplicacion)
            {
                // Crear una nueva multiplicación solo si se permite mostrar la multiplicación
                int factor1 = Random.Range(1, 11);
                int factor2 = Random.Range(1, 11);
                resultadoCorrecto = factor1 * factor2;

                // Actualizar el texto de la multiplicación
                textoMultiplicacion.text = $"{factor1} x {factor2} = ?";
                mostrarMultiplicacion = false;  // Desactivar la posibilidad de mostrar más multiplicaciones
            }

            CrearPlaneta();

            yield return new WaitForSeconds(3f);  // Esperar antes de generar el siguiente planeta
        }
    }

    public void CrearPlaneta()
    {
        float randomY = Random.Range(-5.25f, 5.25f);

        GameObject nuevoPlaneta = Instantiate(prefabPlaneta) as GameObject;
        nuevoPlaneta.transform.position = new Vector3(9.9f, randomY, 0f);

        PlanetaScript planetaScript = nuevoPlaneta.GetComponent<PlanetaScript>();

        if (planetaScript != null)
        {
            // Configurar el componente PlanetaScript con el resultado correcto
            planetaScript.EstablecerResultado(resultadoCorrecto);

            // Configurar valores de texto directamente en el script del planeta
            TextMesh textoResultado = planetaScript.GetComponentInChildren<TextMesh>();
            if (textoResultado != null)
            {
                ConfigurarValoresTexto(textoResultado);
            }

            // Aplicar fuerza al planeta
            nuevoPlaneta.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-70f, 0f));
        }
    }

    void ConfigurarValoresTexto(TextMesh textoResultado)
    {
        // Configurar el valor único del planeta
        textoResultado.text = resultadoCorrecto.ToString();
    }
}










// este codigo funciona bien
public class PlanetaScript : MonoBehaviour
{
    private int resultado;

    

    public void EstablecerResultado(int nuevoResultado)
    {
        resultado = nuevoResultado;
    }

    public int ObtenerResultado()
    {
        return resultado;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Nave"))
        {
            ProcesarColisionNave();
        }
    }

    private void ProcesarColisionNave()
    {
        int respuestaSeleccionada = ObtenerResultado();

        if (respuestaSeleccionada == resultado)
        {
            // La respuesta es correcta, otorgar premio en puntaje
            AumentarPuntaje();
        }
        else
        {
            // La respuesta es incorrecta, estrellar la nave
            EstrellarNave();
        }
    }

    private void AumentarPuntaje()
    {
        // Implementa aquí la lógica para aumentar el puntaje
        Debug.Log("Respuesta correcta. Aumentar puntaje.");
        // Puedes agregar tu propia lógica para aumentar el puntaje del jugador.
    }

    private void EstrellarNave()
    {
        // Implementa aquí la lógica para estrellar la nave
        Debug.Log("Respuesta incorrecta. Estrellar la nave.");
        // Puedes agregar tu propia lógica para manejar la colisión incorrecta con la nave.
    }

}





//Este codigo esta funcionando bien hasta el punto que se genera la multiplicacion y 
//los valores aleatorios a los planetas, pero estos valores no estan siendo controlados
public class PlanetaScript : MonoBehaviour
{
    private int resultado;

    private GeneradorPlanetas generadorPlanetas; // Referencia al script GeneradorPlanetas

    private void Start()
    {
        // Obtener la referencia al script GeneradorPlanetas
        generadorPlanetas = FindObjectOfType<GeneradorPlanetas>();
    }



    public void EstablecerResultado(int nuevoResultado)
    {
        resultado = nuevoResultado;
        ConfigurarValoresTexto();
    }


    // Método para verificar si el planeta tiene el resultado correcto de la multiplicación
    public bool TieneResultadoCorrecto()
    {
        return ObtenerResultado() == generadorPlanetas.ResultadoCorrecto();
    }

    private void ConfigurarValoresTexto()
    {
        TextMesh textoResultado = GetComponentInChildren<TextMesh>();

        if (textoResultado != null)
        {
            // Limpiar cualquier valor anterior
            textoResultado.text = "";

            // Configurar el valor correcto
            textoResultado.text = resultado.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Nave"))
        {
            ProcesarColisionNave(other.gameObject.GetComponent<PlanetaScript>());
        }
    }

    private void ProcesarColisionNave(PlanetaScript planetaColisionado)
    {

        // if (planetaColisionado != null && planetaColisionado == this)
         if (planetaColisionado != null)
        {
            if (planetaColisionado.ObtenerResultado() == resultado)
            {
                AumentarPuntaje();

                // Reiniciar los valores aleatorios para la próxima multiplicación
                generadorPlanetas.CrearPlaneta();

                // Imprimir mensaje en la consola
                Debug.Log("Colisión con el planeta que tiene la respuesta correcta a la multiplicación.");
            }
        else
        {
            EstrellarNave();
        }
        }
    }

    private void AumentarPuntaje()
    {
        Debug.Log("Respuesta correcta. Aumentar puntaje.");
    }

    private void EstrellarNave()
    {
        Debug.Log("Respuesta incorrecta. Estrellar la nave.");
    }

    public int ObtenerResultado()
    {
        return resultado;
    }
}








// ESTE CODIGO HASTA EL 05 DE MARZO ESTA FUNCIONADO JUNTO AL GENERADOR DE PLANETAS DEL LA MISMA FECHA
public class PlanetaScript : MonoBehaviour
{
    private int resultado;

    private GeneradorPlanetas generadorPlanetas; // Referencia al script GeneradorPlanetas

   

    private void Start()
    {

        Debug.Log("Start method in PlanetaScript is called.");
        // Obtener la referencia al script GeneradorPlanetas
        generadorPlanetas = FindObjectOfType<GeneradorPlanetas>();
         if (generadorPlanetas == null)
    {
        Debug.LogError("No se encontró el script GeneradorPlanetas.");
    }
        
    }

 
    public void EstablecerResultado(int nuevoResultado)
    {
        resultado = nuevoResultado;
        ConfigurarValoresTexto();
    }

    // Método para verificar si el planeta tiene el resultado correcto de la multiplicación
    public bool TieneResultadoCorrecto()
    {
        //return ObtenerResultado() == generadorPlanetas.ObtenerResultadoCorrecto();
        return ObtenerResultado() == FindObjectOfType<GeneradorPlanetas>().ObtenerResultadoCorrecto();
    }

    private void ConfigurarValoresTexto()
    {
        
        TextMesh textoResultado = GetComponentInChildren<TextMesh>();
        
        if (textoResultado != null)
        {
            // Limpiar cualquier valor anterior
            textoResultado.text = "";

            // Configurar el valor correcto
            textoResultado.text = resultado.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Nave"))
        {
            Debug.Log("Colisión con la nave detectada.");
            ProcesarColisionNave(other.gameObject.GetComponent<PlanetaScript>());
        }
    }

    private void ProcesarColisionNave(PlanetaScript planetaColisionado)
    {
        if (planetaColisionado != null)
        {
          if (planetaColisionado.ObtenerResultado() == resultado)
            {
                AumentarPuntaje();
                 generadorPlanetas.ReiniciarGeneracion();
            Debug.Log("Colisión con el planeta que tiene la respuesta correcta a la multiplicación.");




//   if (planetaColisionado != null && planetaColisionado.ObtenerResultado() == resultado)
//        {
//            AumentarPuntaje();
//            FindObjectOfType<GeneradorPlanetas>().ReiniciarGeneracion();
//            Debug.Log("Colisión con el planeta que tiene la respuesta correcta a la multiplicación.");
//        }


                 //FindObjectOfType<GeneradorPlanetas>().ReiniciarMostrarMultiplicacion();
                  //FindObjectOfType<GeneradorPlanetas>().ReiniciarGeneracion();
                 // generadorPlanetas.StartCoroutine(generadorPlanetas.GenerarMultiplicacion());



                  //  GeneradorPlanetas generadorPlanetas = FindObjectOfType<GeneradorPlanetas>();
           // if (generadorPlanetas != null)
           // { 
              //   generadorPlanetas.ReiniciarGeneracion();
                 
          //  }
            // else
           // {
          //      Debug.LogError("No se pudo encontrar el GeneradorPlanetas.");
          //  }






                // Reiniciar los valores aleatorios para la próxima multiplicación
                //generadorPlanetas.CrearPlaneta();

                // Imprimir mensaje en la consola
    //            Debug.Log("Colisión con el planeta que tiene la respuesta correcta a la multiplicación.");
            }
            else
            {
                EstrellarNave();
            }
        }
    
    }
    private void AumentarPuntaje()
    {
        Debug.Log("Respuesta correcta. Aumentar puntaje.");
    }

    private void EstrellarNave()
    {
        Debug.Log("Respuesta incorrecta. Estrellar la nave.");
    }

    public int ObtenerResultado()
    {
        return resultado;
    }

   public void LimpiarValor()
    {
        resultado = 0;  // O cualquier otro valor que represente la ausencia de un resultado
    }


}
// FECHA 05 DE MARZO

*/









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
            GeneradorPlanetas gameManager = GameObject.FindObjectOfType<GeneradorPlanetas>();

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
