using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ControlTerceroDecimal : MonoBehaviour
{


     public GameObject[] esferaPrefab;
    public Transform centroDePantalla;
    public int cantidadEsferasOrbita1 = 8;
    public int cantidadEsferasOrbita2 = 8;
    public float radioOrbita1 = 5f;
    public float radioOrbita2 = 10f;
    public float velocidadRotacionOrbita1 = 10f;
    public float velocidadRotacionOrbita2 = 10f;



      public HashSet<string> preguntasRespondidas = new HashSet<string>(); // Registro de preguntas respondidas





public TextMeshProUGUI contadorText;
private int contador = 0;
//private int totalFiguras = 3;


public AudioClip sonidoCorrecto;
public AudioClip sonidoIncorrecto;



private int contadorIncorrectas = 0;
public TextMeshProUGUI textoContadorIncorrectas;
private int totalFallas = 3;

 // Diccionario para asociar cada suma con su resultado
    public static Dictionary<string, string> nombreFiguraRespuesta = new Dictionary<string, string>()
{
        { "DosCinco", "Sumar: 1.9 + 0.6" },
        { "Uno", "Sumar: 0.3 + 0.7" },
        { "UnoUno", "Sumar: 0.6 + 0.5" },
        { "UnoDos", "Sumar: 0.3 + 0.9" },
        { "UnoTres", "Sumar: 0.2 + 1.1"  },
        { "UnoCuatro", "Sumar: 0.7 + 0.7" },
        { "UnoCinco", "Sumar: 1.0 + 0.5" },
        { "UnoSeis", "Sumar: 0.4 + 1.2" },
        { "UnoSiete", "Sumar: 0.8 + 0.9" },
        { "UnoOcho", "Sumar: 0.3 + 1.5" },
        { "UnoNueve", "Sumar: 1.7 + 0.2" },
        { "Dos", "Sumar: 1.2 + 0.8" },
        { "DosUno", "Sumar: 0.3 + 1.8" },
        { "DosDos", "Sumar: 2.0 + 0.2" },
        { "DosTres", "Sumar: 0.9 + 1.4" },
        { "DosCuatro", "Sumar: 1.2 + 1.2" }

};

public List<Pregunta> preguntas = new List<Pregunta>()
{
    new Pregunta("Sumar: 1.9 + 0.6", "DosCinco"),
    new Pregunta("Sumar: 0.3 + 0.7", "Uno"),
    new Pregunta("Sumar: 0.6 + 0.5", "UnoUno"),
    new Pregunta("Sumar: 0.3 + 0.9", "UnoDos"),
    new Pregunta("Sumar: 0.2 + 1.1", "UnoTres"),
    new Pregunta("Sumar: 0.7 + 0.7", "UnoCuatro"),
    new Pregunta("Sumar: 1.0 + 0.5", "UnoCinco"),
    new Pregunta("Sumar: 0.4 + 1.2", "UnoSeis"),
    new Pregunta("Sumar: 0.8 + 0.9", "UnoSiete"),
    new Pregunta("Sumar: 0.3 + 1.5", "UnoOcho"),
    new Pregunta("Sumar: 1.7 + 0.2", "UnoNueve"),
    new Pregunta("Sumar: 1.2 + 0.8", "Dos"),
    new Pregunta("Sumar: 0.3 + 1.8", "DosUno"),
    new Pregunta("Sumar: 2.0 + 0.2", "DosDos"),
    new Pregunta("Sumar: 0.9 + 1.4", "DosTres"),
    new Pregunta("Sumar: 1.2 + 1.2", "DosCuatro"), 

};
public TextMeshProUGUI textoPregunta;

   





    void Start()
    {
         StartCoroutine(ReproducirInstrucciones());
        GenerarEsferas();
           



         // Seleccionar pregunta aleatoria
        int indicePregunta = Random.Range(0, preguntas.Count);
        Pregunta preguntaSeleccionada = preguntas[indicePregunta];
        textoPregunta.text = preguntaSeleccionada.pregunta;

        


        // Obtener la respuesta correcta asociada al nombre de la figura
        string nombreFigura = preguntaSeleccionada.respuesta;
string pregunta = preguntas.Find(p => p.respuesta == nombreFigura).pregunta;
//Debug.Log("Respuesta correcta: " + nombreFigura);
// Debug.Log("Nombre de la figura: " + nombreFigura + ", Pregunta asociada: " + pregunta);

    }


     void GenerarEsferas()
    {
         Vector3 centroPantalla = new Vector3(Screen.width / 2f, Screen.height / 2f, 10f);
         centroPantalla = Camera.main.ScreenToWorldPoint(centroPantalla);
       // Vector3 centroPantalla = centroDePantalla.position;
        GenerarEsferasEnOrbita(cantidadEsferasOrbita1, radioOrbita1, centroPantalla, velocidadRotacionOrbita1);
        GenerarEsferasEnOrbita(cantidadEsferasOrbita2, radioOrbita2, centroPantalla, velocidadRotacionOrbita2);
    }

    void GenerarEsferasEnOrbita(int cantidadEsferas, float radioOrbita, Vector3 centro, float velocidadRotacion)
    {
     


                for (int i = 0; i < cantidadEsferasOrbita1; i++)
    {
        float angulo = i * (360f / cantidadEsferasOrbita1);
        Vector3 posicion = centro + Quaternion.Euler(0, 0, angulo) * Vector3.right * radioOrbita1;
        GameObject esfera = Instantiate(esferaPrefab[i], posicion, Quaternion.identity);
        esfera.transform.SetParent(transform);
        EsferaRotator rotator = esfera.AddComponent<EsferaRotator>();
            rotator.centro = centro;
            rotator.velocidadRotacion = velocidadRotacion;
    }

    for (int i = 0; i < cantidadEsferasOrbita2; i++)
    {
        float angulo = i * (360f / cantidadEsferasOrbita2);
        Vector3 posicion = centro + Quaternion.Euler(0, 0, angulo) * Vector3.right * radioOrbita2;
        GameObject esfera = Instantiate(esferaPrefab[cantidadEsferasOrbita1 + i], posicion, Quaternion.identity);
        esfera.transform.SetParent(transform);

        EsferaRotator rotator = esfera.AddComponent<EsferaRotator>();
            rotator.centro = centro;
            rotator.velocidadRotacion = velocidadRotacion;
    } 


            
        
    }




// Estructura para representar preguntas y respuestas
    [System.Serializable]
    public struct Pregunta
    {
        public string pregunta;
        public string respuesta;

        public Pregunta(string pregunta, string respuesta)
        {
            this.pregunta = pregunta;
            this.respuesta = respuesta;
        }
    }
    
    
  

public void GenerarPreguntaAleatoria()
{
   

     // Obtener una lista de preguntas que no han sido respondidas correctamente
        List<Pregunta> preguntasDisponibles = new List<Pregunta>();
        foreach (var pregunta in preguntas)
        {
            if (!preguntasRespondidas.Contains(pregunta.respuesta))
            {
                preguntasDisponibles.Add(pregunta);
            }
        }

        // Verificar si quedan preguntas disponibles para responder
        if (preguntasDisponibles.Count > 0)
        {
            // Seleccionar una pregunta aleatoria de las disponibles
            int indicePregunta = Random.Range(0, preguntasDisponibles.Count);
            Pregunta preguntaSeleccionada = preguntasDisponibles[indicePregunta];

            textoPregunta.text = preguntaSeleccionada.pregunta;
        }
        else
        {
            // Aquí puedes agregar lógica para manejar el caso en que no quedan preguntas disponibles
            Debug.Log("No quedan preguntas disponibles.");

            // Puedes reiniciar el juego o mostrar un mensaje al jugador
        }

    
    
}





public bool VerificarRespuesta(string respuestaSeleccionada, string nombreFigura)
{
    // Buscar la pregunta que coincide con el texto de la pregunta mostrada
    Pregunta preguntaSeleccionada = preguntas.Find(p => p.pregunta == textoPregunta.text);
    
    // Verificar si la respuesta seleccionada es correcta
    if (respuestaSeleccionada.Equals(preguntaSeleccionada.respuesta))
    {
        AudioSource.PlayClipAtPoint(sonidoCorrecto, transform.position);
        contador++;
        contadorText.text = contador + "/" +  preguntas.Count;

                  preguntasRespondidas.Add(preguntaSeleccionada.respuesta);
             if (preguntasRespondidas.Count >= 16)
        {
             SceneManager.LoadScene(24);
            // Aquí puedes agregar lógica adicional si se responden correctamente todas las preguntas
            Debug.Log("¡Ganaste!");
        }





        Debug.Log("Respuesta correcta: " + respuestaSeleccionada);
        return true;
    }
    else
    {
        Debug.Log("Respuesta incorrecta. La respuesta correcta era: " + preguntaSeleccionada.respuesta + ". Figura seleccionada: " + nombreFigura);
       AudioSource.PlayClipAtPoint(sonidoIncorrecto, transform.position);
       contadorIncorrectas++;
        textoContadorIncorrectas.text = contadorIncorrectas + "/" + totalFallas;// preguntas.Count;
        if(contadorIncorrectas==totalFallas)
        {
            SceneManager.LoadScene("GameOver");
        }
        return false;
    }
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









void Update()
    {
        // Rotar el eje central
        // transform.Rotate(Vector3.forward * velocidadRotacionOrbita1 * Time.deltaTime);
      
    }



}


public class EsferaRotator : MonoBehaviour
{
    public Vector3 centro;
    public float velocidadRotacion;

    void Update()
    {
        transform.RotateAround(centro, Vector3.forward, velocidadRotacion * Time.deltaTime);
    }










}