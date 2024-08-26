using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Controlador : MonoBehaviour
{
    public GameObject nivelCompletado;
    public GameObject gameOver;
    public GameObject[] formasPrefabs;
    public float separacionX = 4f;
    public float alturaY = -1f;
    private int[] indices;
    public HashSet<string> preguntasRespondidas = new HashSet<string>();
    public TextMeshProUGUI contadorText;
    private int contador = 0;
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

        int formasPorFila = 8;
        float separacionY = 2f;
        float alturaYPrimeraFila = -1f;

        float inicioX = -((formasPorFila - 1) * separacionX) / 2f + separacionX / 2f;

        indices = RandomizeArray(formasPrefabs.Length);

        for (int i = 0; i < formasPrefabs.Length; i++)
        {

            int indice = indices[i];

            float posX = inicioX + (i % formasPorFila) * separacionX;
            float posY = i < formasPorFila ? alturaYPrimeraFila : alturaYPrimeraFila - separacionY;

            GameObject forma = Instantiate(formasPrefabs[indices[i]], new Vector3(posX, posY, 0f), Quaternion.identity, transform);
            forma.name = formasPrefabs[indices[i]].name;


        }
        int indicePregunta = Random.Range(0, preguntas.Count);
        Pregunta preguntaSeleccionada = preguntas[indicePregunta];
        textoPregunta.text = preguntaSeleccionada.pregunta;
        string nombreFigura = preguntaSeleccionada.respuesta;
        string pregunta = preguntas.Find(p => p.respuesta == nombreFigura).pregunta;
    }

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
        List<Pregunta> preguntasDisponibles = new List<Pregunta>();
        foreach (var pregunta in preguntas)
        {
            if (!preguntasRespondidas.Contains(pregunta.respuesta))
            {
                preguntasDisponibles.Add(pregunta);
            }
        }
        if (preguntasDisponibles.Count > 0)
        {
            int indicePregunta = Random.Range(0, preguntasDisponibles.Count);
            Pregunta preguntaSeleccionada = preguntasDisponibles[indicePregunta];
            textoPregunta.text = preguntaSeleccionada.pregunta;

            int indicePreguntaCompleta = preguntas.FindIndex(p => p.pregunta == preguntaSeleccionada.pregunta);
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
                AudioSource.PlayClipAtPoint(audioPregunta, transform.position, 1.0f);
            }
            else
            {
                Debug.LogError("No se encontró audio asociado a la pregunta seleccionada.");
            }
        }
        else
        {
            Debug.Log("No quedan preguntas disponibles.");
        }
    }
    public bool VerificarRespuesta(string respuestaSeleccionada, string nombreFigura)
    {
        Pregunta preguntaSeleccionada = preguntas.Find(p => p.pregunta == textoPregunta.text);


        if (respuestaSeleccionada.Equals(preguntaSeleccionada.respuesta))
        {
            AudioSource.PlayClipAtPoint(sonidoCorrecto, transform.position, 1.0f);
            contador++;
            contadorText.text = contador + "/" + preguntas.Count;
            preguntasRespondidas.Add(preguntaSeleccionada.respuesta);
            if (preguntasRespondidas.Count >= 16)
            {
                nivelCompletado.gameObject.SetActive(true);
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
            if (contadorIncorrectas == totalFallas)
            {
                gameOver.gameObject.SetActive(true);
                 Debug.Log("GameOver");
            }
            return false;
        }
    }
    IEnumerator ReproducirInstrucciones()
    {
        Time.timeScale = 0f;
        AudioSource audioSource = GameObject.Find("Instrucciones").GetComponent<AudioSource>();
        audioSource.Play();
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        Time.timeScale = 1f;
    }
}