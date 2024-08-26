using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GeneradorSumaFraccion : MonoBehaviour
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
    public HashSet<string> preguntasRespondidas = new HashSet<string>(); // Registro de preguntas respondidas
    public TextMeshProUGUI contadorText;
    private int contador = 0;
    public AudioClip sonidoCorrecto;
    public AudioClip sonidoIncorrecto;
    private int contadorIncorrectas = 0;
    public TextMeshProUGUI textoContadorIncorrectas;
    private int totalFallas = 16;
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
public class EsferaRotator2 : MonoBehaviour
{
    public Vector3 centro;
    public float velocidadRotacion;
    void Update()
    {
        transform.RotateAround(centro, Vector3.forward, velocidadRotacion * Time.deltaTime);
    }
}