using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Controlador : MonoBehaviour
{       

 public GameObject[] formasPrefabs; // Array de prefabs de formas geométricas
 public float separacionX = 4f; // Separación entre formas en el eje X
    public float alturaY = -1f; // Altura a la que aparecen las formas en el eje Y
private int[] indices; // Índices de las formas en orden aleatorio



 public HashSet<string> preguntasRespondidas = new HashSet<string>(); // Registro de preguntas respondida



public TextMeshProUGUI contadorText;
private int contador = 0;
//private int totalFiguras = 3;


public AudioClip sonidoCorrecto;
public AudioClip sonidoIncorrecto;



private int contadorIncorrectas = 0;
public TextMeshProUGUI textoContadorIncorrectas;
private int totalFallas = 3;

public static Dictionary<string, string> nombreFiguraRespuesta = new Dictionary<string, string>()
{
        { "Capsula", "¿Cuál de estas figuras es un Capsula?" },
        { "Cilindro", "¿Cuál de estas figuras es un Cilindro?" },
        { "Circulo", "¿Cuál de estas figuras es un Círculo?" },
        { "Cono", "¿Cuál de estas figuras es un Cono?" },
        { "Corazon", "¿Cuál de estas figuras es un Corazon?" },
        { "Cuadrado", "¿Cuál de estas figuras es un Cuadrado?" },
        { "Cubo", "¿Cuál de estas figuras es un Cubo?" },
        { "Diamante", "¿Cuál de estas figuras es un Diamante?" },
        { "Esfera", "¿Cuál de estas figuras es un Esfera?" },
        { "Estrella", "¿Cuál de estas figuras es un Estrella?" },
        { "Hexagono", "¿Cuál de estas figuras es un Hexagono?" },
        { "Ovalo", "¿Cuál de estas figuras es un Ovalo?" },
        { "Pentagono", "¿Cuál de estas figuras es un Pentagono?" },
        { "Piramide", "¿Cuál de estas figuras es un Piramide?" },
        { "Rectangulo", "¿Cuál de estas figuras es un Rectangulo?" },
        { "Triangulo", "¿Cuál de estas figuras es un Triangulo?" }
    };

public List<Pregunta> preguntas = new List<Pregunta>()
    {
        new Pregunta("¿Cuál de estas figuras es un triángulo?", "Triangulo"),
        new Pregunta("¿Cuál de estas figuras es un cuadrado?", "Cuadrado"),
         new Pregunta("¿Cuál de estas figuras es un circulo?", "Circulo"),
          new Pregunta("¿Cuál de estas figuras es un Hexagono?", "Hexagono"),
           new Pregunta("¿Cuál de estas figuras es un Rectangulo?", "Rectangulo"),
            new Pregunta("¿Cuál de estas figuras es un Pentagono?", "Pentagono"),
             new Pregunta("¿Cuál de estas figuras es un Piramide?", "Piramide"),
              new Pregunta("¿Cuál de estas figuras es un Estrella?", "Estrella"),
               new Pregunta("¿Cuál de estas figuras es un Ovalo?", "Ovalo"),
                new Pregunta("¿Cuál de estas figuras es un Esfera?", "Esfera"),
                 new Pregunta("¿Cuál de estas figuras es un Diamante?", "Diamante"),
                  new Pregunta("¿Cuál de estas figuras es un Cubo?", "Cubo"),
                  new Pregunta("¿Cuál de estas figuras es un Corazon?", "Corazon"),
                  new Pregunta("¿Cuál de estas figuras es un Cono?", "Cono"),
                  new Pregunta("¿Cuál de estas figuras es un Cilindro?", "Cilindro"),
                  new Pregunta("¿Cuál de estas figuras es un Capsula?", "Capsula"),
          
       
    };

public TextMeshProUGUI textoPregunta;

   
public AudioClip[] sonidosPreguntas;




    void Start()
    {

    StartCoroutine(ReproducirInstrucciones());









int formasPorFila = 8; // Número de formas por fila
    float separacionY = 2f; // Separación vertical entre las filas
    float alturaYPrimeraFila = -1f; // Altura de la primera fila




    // Calcular la posición inicial en X
    float inicioX = -((formasPorFila - 1) * separacionX) / 2f + separacionX / 2f;

// Obtener índices aleatorios
    indices = RandomizeArray(formasPrefabs.Length);






    // Generar formas geométricas en dos filas
    for (int i = 0; i < formasPrefabs.Length; i++)
    {
        
 // Obtener el índice aleatorio
        int indice = indices[i];


        // Calcular posición para esta forma
        float posX = inicioX + (i % formasPorFila) * separacionX;
        float posY = i < formasPorFila ? alturaYPrimeraFila : alturaYPrimeraFila - separacionY;

        // Instanciar la forma geométrica
        GameObject forma = Instantiate(formasPrefabs[indices[i]], new Vector3(posX, posY, 0f), Quaternion.identity, transform);
        forma.name = formasPrefabs[indices[i]].name; // Asignar el nombre de la forma al objeto


    }



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

    // Función para obtener un array de índices en orden aleatorio
    int[] RandomizeArray(int length)
    {
        int[] indices = new int[length];
        for (int i = 0; i < length; i++)
        {
            indices[i] = i;
        }
        for (int i = 0; i < length - 1; i++)
        {
            int r = Random.Range(i, length);
            int temp = indices[i];
            indices[i] = indices[r];
            indices[r] = temp;
        }
        return indices;
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



              // Buscar el índice de la pregunta seleccionada en la lista completa de preguntas
        int indicePreguntaCompleta = preguntas.FindIndex(p => p.pregunta == preguntaSeleccionada.pregunta);

        // Buscar el audio asociado a la pregunta seleccionada
        AudioClip audioPregunta = null;
        foreach (var pregunta in preguntas)
        {
            if (pregunta.pregunta == preguntaSeleccionada.pregunta)
            {
                audioPregunta = sonidosPreguntas[preguntas.IndexOf(pregunta)];
                break;
            }
        }

        if (audioPregunta != null)
        {
            AudioSource.PlayClipAtPoint(audioPregunta, transform.position);
        }
        else
        {
            Debug.LogError("No se encontró audio asociado a la pregunta seleccionada.");
        }

         

           


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







}