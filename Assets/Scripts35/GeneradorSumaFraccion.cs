using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GeneradorSumaFraccion : MonoBehaviour
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





//     public GameObject[] esferasPrefabs; // Array de prefabs de formas geométricas
// public float separacionX = 2f; // Separación entre formas en el eje X
//    public float alturaY = -1f; // Altura a la que aparecen las formas en el eje Y
//private int[] indices; // Índices de las formas en orden aleatorio



public TextMeshProUGUI contadorText;
private int contador = 0;
//private int totalFiguras = 3;


public AudioClip sonidoCorrecto;
public AudioClip sonidoIncorrecto;



private int contadorIncorrectas = 0;
public TextMeshProUGUI textoContadorIncorrectas;
private int totalFallas = 16;

 // Diccionario para asociar cada suma con su resultado
    public static Dictionary<string, string> nombreFiguraRespuesta = new Dictionary<string, string>()
{
        { "SeisOcho", "Sumar Faccion: 1/2 + 1/4" },
        { "OchoSeis", "Sumar Faccion: 2/2 + 1/3" },
        { "DiezVentiCuatro", "Sumar Faccion: 1/4 + 1/6" },
        { "DosTres", "Sumar Faccion: 1/3 + 1/3" },
        { "TresCuatro", "Sumar Faccion: 2/4 + 1/4"  },
        { "OnceTreinta", "Sumar Faccion: 1/5 + 1/6" },
        { "OchoDoce", "Sumar Faccion: 1/6 + 1/2" },
        { "DieciseisCatorce", "Sumar Faccion: 1/7 + 2/2" },
        { "DiecinueveVentiCuatro", "Sumar Faccion: 1/8 + 2/3" },
        { "VentiDosTreintaSeis", "Sumar Faccion: 1/9 + 2/4" },
        { "CatorceDiez", "Sumar Faccion: 2/2 + 2/5" },
        { "TreceQuince", "Sumar Faccion: 2/3 + 1/5" },
        { "DieciochoVentiOcho", "Sumar Faccion: 2/4 + 1/7" },
        { "VentiUnoCuarenta", "Sumar Faccion: 2/5 + 1/8" },
        { "VentiCuatroCincuentaCuatro", "Sumar Faccion: 2/6 + 1/9" },
        { "VentiSieteVentiUno", "Sumar Faccion: 2/7 + 3/3" }

};

public List<Pregunta> preguntas = new List<Pregunta>()
{
    new Pregunta("Sumar Faccion: 1/2 + 1/4", "SeisOcho"),
    new Pregunta("Sumar Faccion: 2/2 + 1/3", "OchoSeis"),
    new Pregunta("Sumar Faccion: 1/4 + 1/6", "DiezVentiCuatro"),
    new Pregunta("Sumar Faccion: 1/3 + 1/3", "DosTres"),
    new Pregunta("Sumar Faccion: 2/4 + 1/4", "TresCuatro"),
    new Pregunta("Sumar Faccion: 1/5 + 1/6", "OnceTreinta"),
    new Pregunta("Sumar Faccion: 1/6 + 1/2", "OchoDoce"),
    new Pregunta("Sumar Faccion: 1/7 + 2/2", "DieciseisCatorce"),
    new Pregunta("Sumar Faccion: 1/8 + 2/3", "DiecinueveVentiCuatro"),
    new Pregunta("Sumar Faccion: 1/9 + 2/4", "VentiDosTreintaSeis"),
    new Pregunta("Sumar Faccion: 2/2 + 2/5", "CatorceDiez"),
    new Pregunta("Sumar Faccion: 2/3 + 1/5", "TreceQuince"),
    new Pregunta("Sumar Faccion: 2/4 + 1/7", "DieciochoVentiOcho"),
    new Pregunta("Sumar Faccion: 2/5 + 1/8", "VentiUnoCuarenta"),
    new Pregunta("Sumar Faccion: 2/6 + 1/9", "VentiCuatroCincuentaCuatro"),
    new Pregunta("Sumar Faccion: 2/7 + 3/3", "VentiSieteVentiUno"), 

};
public TextMeshProUGUI textoPregunta;

   





    void Start()
    {
        GenerarEsferas();
        //    StartCoroutine(ReproducirInstrucciones());




//    int formasPorFila = 8; // Número de formas por fila
//    float separacionY = 2f; // Separación vertical entre las filas
//    float alturaYPrimeraFila = 3f; // Altura de la primera fila




    // Calcular la posición inicial en X
//    float inicioX = -((formasPorFila - 1) * separacionX) / 2f + separacionX / 2f;

    // Obtener índices aleatorios
//    indices = RandomizeArray(esferasPrefabs.Length);






    // Generar formas geométricas en dos filas
//    for (int i = 0; i < esferasPrefabs.Length; i++)
//    {
        
      // Obtener el índice aleatorio
//        int indice = indices[i];


        // Calcular posición para esta forma
//        float posX = inicioX + (i % formasPorFila) * separacionX;
//        float posY = i < formasPorFila ? alturaYPrimeraFila : alturaYPrimeraFila - separacionY;

        // Instanciar la forma geométrica
//        GameObject forma = Instantiate(esferasPrefabs[indices[i]], new Vector3(posX, posY, 0f), Quaternion.identity, transform);
//        forma.name = esferasPrefabs[indices[i]].name; // Asignar el nombre de la forma al objeto




           // Instanciar la forma geométrica
          //        GameObject forma = Instantiate(formasPrefabs[i], new Vector3(posX, posY, 0f), Quaternion.identity, transform);
           //       forma.name = formasPrefabs[i].name; // Asignar el nombre de la forma al objeto
//    }


         // Inicializar el diccionario nombreFiguraRespuesta
         //        foreach (var pregunta in preguntas)
        //        {
        //            nombreFiguraRespuesta.Add(pregunta.respuesta, pregunta.pregunta);
         //        }



         // Seleccionar pregunta aleatoria
        int indicePregunta = Random.Range(0, preguntas.Count);
        Pregunta preguntaSeleccionada = preguntas[indicePregunta];
        textoPregunta.text = preguntaSeleccionada.pregunta;

        // AudioClip audioPregunta = sonidosPreguntas[indicePregunta];
         // AudioSource.PlayClipAtPoint(audioPregunta, transform.position);
        //       Debug.Log("Pregunta: " + preguntaSeleccionada.pregunta);


        // Obtener la respuesta correcta asociada al nombre de la figura
        string nombreFigura = preguntaSeleccionada.respuesta;
string pregunta = preguntas.Find(p => p.respuesta == nombreFigura).pregunta;
//Debug.Log("Respuesta correcta: " + nombreFigura);
// Debug.Log("Nombre de la figura: " + nombreFigura + ", Pregunta asociada: " + pregunta);





//        indices = RandomizeArray(formasPrefabs.Length); // Obtener índices aleatorios

        // Calcular la posición inicial en X
//       float inicioX = -((formasPrefabs.Length - 1) * separacionX) / 2f + separacionX / 2f;

        // Generar formas geométricas en el orden aleatorio
//        for (int i = 0; i < formasPrefabs.Length; i++)
//        {
            // Obtener el índice aleatorio
//            int indice = indices[i];

            // Calcular posición para esta forma
//            float posX = inicioX + i * separacionX;
//            float posY = alturaY; // Altura ajustable en el eje Y

            // Instanciar la forma geométrica
//            GameObject forma = Instantiate(formasPrefabs[indice], new Vector3(posX, posY, 0f), Quaternion.identity, transform);
//            forma.name = formasPrefabs[indice].name; // Asignar el nombre de la forma al objeto
//        }


 

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
      // for (int i = 0; i < cantidadEsferas; i++)
      //  {
      //      float angulo = i * (360f / cantidadEsferas);
      //      Vector3 posicion = centro + Quaternion.Euler(0, 0, angulo) * Vector3.right * radioOrbita;
       //     GameObject esfera = Instantiate(esferaPrefab[i], posicion, Quaternion.identity);
       //     esfera.transform.SetParent(transform); // Asignar como hijo del objeto ControlTerceroDecimal
       // }


                for (int i = 0; i < cantidadEsferasOrbita1; i++)
    {
        float angulo = i * (360f / cantidadEsferasOrbita1);
        Vector3 posicion = centro + Quaternion.Euler(0, 0, angulo) * Vector3.right * radioOrbita1;
        GameObject esfera = Instantiate(esferaPrefab[i], posicion, Quaternion.identity);
        esfera.transform.SetParent(transform);
        EsferaRotator2 rotator = esfera.AddComponent<EsferaRotator2>();
            rotator.centro = centro;
            rotator.velocidadRotacion = velocidadRotacion;
    }

    for (int i = 0; i < cantidadEsferasOrbita2; i++)
    {
        float angulo = i * (360f / cantidadEsferasOrbita2);
        Vector3 posicion = centro + Quaternion.Euler(0, 0, angulo) * Vector3.right * radioOrbita2;
        GameObject esfera = Instantiate(esferaPrefab[cantidadEsferasOrbita1 + i], posicion, Quaternion.identity);
        esfera.transform.SetParent(transform);

        EsferaRotator2 rotator = esfera.AddComponent<EsferaRotator2>();
            rotator.centro = centro;
            rotator.velocidadRotacion = velocidadRotacion;
    } 


            
        
    }














    // Función para obtener un array de índices en orden aleatorio
//    int[] RandomizeArray(int length)
//    {
//        int[] indices = new int[length];
//        for (int i = 0; i < length; i++)
//        {
//            indices[i] = i;
//        }
//        for (int i = 0; i < length - 1; i++)
//        {
//            int r = Random.Range(i, length);
//            int temp = indices[i];
//            indices[i] = indices[r];
//            indices[r] = temp;
//        }
//        return indices;
//    }

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
    //int indicePregunta = Random.Range(0, preguntas.Count);
   // Pregunta preguntaSeleccionada = preguntas[indicePregunta];
    //textoPregunta.text = preguntaSeleccionada.pregunta;

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
             SceneManager.LoadScene(26);
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





void Update()
    {
        // Rotar el eje central
        // transform.Rotate(Vector3.forward * velocidadRotacionOrbita1 * Time.deltaTime);
      
    }



}


public class EsferaRotator2 : MonoBehaviour
{
    public Vector3 centro;
    public float velocidadRotacion;

    void Update()
    {
        transform.RotateAround(centro, Vector3.forward, velocidadRotacion * Time.deltaTime);
    }
}