using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GeneradorRestaDecimal : MonoBehaviour
{
    public GameObject nivelCompletado;
    public GameObject gameOver;
    public GameObject[] esferaPrefab;
    public Transform centroDePantalla;
    public int cantidadEsferasOrbita1 = 8;
    public int cantidadEsferasOrbita2 = 8;
    public float radioOrbita1 = 5f;
    public float radioOrbita2 = 10f;
    public float velocidadRotacionOrbita1 = 10f;
    public float velocidadRotacionOrbita2 = 10f;
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
        { "CeroCinco", "Restar: 1.8 - 1.3" },
        { "CeroSeis", "Restar: 1.0 - 0.4" },
        { "CeroSiete", "Restar: 2.6 - 1.9" },
        { "CeroOcho", "Restar: 1.4 - 0.6" },
        { "CeroNueve", "Restar: 2.0 - 1.1"  },
        { "Uno", "Restar: 2.8 - 1.8" },
        { "UnoUno", "Restar: 1.6 - 0.5" },
        { "UnoDos", "Restar: 2.4 - 1.2" },
        { "UnoTres", "Restar: 1.5 - 0.2" },
        { "UnoCuatro", "Restar: 2.9 - 1.5" },
        { "UnoCinco", "Restar: 1.8 - 0.3" },
        { "UnoSeis", "Restar: 1.7 - 0.1" },
        { "UnoSiete", "Restar: 3.2 - 1.5" },
        { "UnoOcho", "Restar: 2.2 - 0.4" },
        { "UnoNueve", "Restar: 2.1 - 0.2" },
        { "Dos", "Restar: 3.0 - 1.0" }

};
    public List<Pregunta> preguntas = new List<Pregunta>()
{
    new Pregunta("Restar: 1.8 - 1.3", "CeroCinco"),
    new Pregunta("Restar: 1.0 - 0.4", "CeroSeis"),
    new Pregunta("Restar: 2.6 - 1.9", "CeroSiete"),
    new Pregunta("Restar: 1.4 - 0.6", "CeroOcho"),
    new Pregunta("Restar: 2.0 - 1.1", "CeroNueve"),
    new Pregunta("Restar: 2.8 - 1.8", "Uno"),
    new Pregunta("Restar: 1.6 - 0.5", "UnoUno"),
    new Pregunta("Restar: 2.4 - 1.2", "UnoDos"),
    new Pregunta("Restar: 1.5 - 0.2", "UnoTres"),
    new Pregunta("Restar: 2.9 - 1.5", "UnoCuatro"),
    new Pregunta("Restar: 1.8 - 0.3", "UnoCinco"),
    new Pregunta("Restar: 1.7 - 0.1", "UnoSeis"),
    new Pregunta("Restar: 3.2 - 1.5", "UnoSiete"),
    new Pregunta("Restar: 2.2 - 0.4", "UnoOcho"),
    new Pregunta("Restar: 2.1 - 0.2", "UnoNueve"),
    new Pregunta("Restar: 3.0 - 1.0", "Dos"),

};
    public TextMeshProUGUI textoPregunta;
    void Start()
    {
        GenerarEsferas();
        int indicePregunta = Random.Range(0, preguntas.Count);
        Pregunta preguntaSeleccionada = preguntas[indicePregunta];
        textoPregunta.text = preguntaSeleccionada.pregunta;
        string nombreFigura = preguntaSeleccionada.respuesta;
        string pregunta = preguntas.Find(p => p.respuesta == nombreFigura).pregunta;
    }





    void GenerarEsferas()
    {
        Vector3 centroPantalla = new Vector3(Screen.width / 2f, Screen.height / 2f, 10f);
        centroPantalla = Camera.main.ScreenToWorldPoint(centroPantalla);
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
            EsferaRotator1 rotator = esfera.AddComponent<EsferaRotator1>();
            rotator.centro = centro;
            rotator.velocidadRotacion = velocidadRotacion;
        }

        for (int i = 0; i < cantidadEsferasOrbita2; i++)
        {
            float angulo = i * (360f / cantidadEsferasOrbita2);
            Vector3 posicion = centro + Quaternion.Euler(0, 0, angulo) * Vector3.right * radioOrbita2;
            GameObject esfera = Instantiate(esferaPrefab[cantidadEsferasOrbita1 + i], posicion, Quaternion.identity);
            esfera.transform.SetParent(transform);

            EsferaRotator1 rotator = esfera.AddComponent<EsferaRotator1>();
            rotator.centro = centro;
            rotator.velocidadRotacion = velocidadRotacion;
        }
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
            AudioSource.PlayClipAtPoint(sonidoCorrecto, transform.position);
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
            }
            return false;
        }
    }
    void Update()
    {
    }
}


public class EsferaRotator1 : MonoBehaviour
{
    public Vector3 centro;
    public float velocidadRotacion;
    void Update()
    {
        transform.RotateAround(centro, Vector3.forward, velocidadRotacion * Time.deltaTime);
    }
}
