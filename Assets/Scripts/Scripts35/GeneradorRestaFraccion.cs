using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GeneradorRestaFraccion : MonoBehaviour
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
        { "DosOcho", "Restar: 3/4 - 1/2" },
        { "UnoQuince", "Restar: 2/5 - 1/3" },
        { "TresVentiOcho", "Restar: 1/4 - 1/7" },
        { "CuatroTreinta", "Restar: 2/6 - 1/5" },
        { "UnCuarto", "Restar: 3/4 - 2/4"  },
        { "UnQuinto", "Restar: 2/5 - 1/5" },
        { "SeisDieciseis", "Restar: 1/2 - 1/8" },
        { "OchoVentiUno", "Restar: 2/3 - 2/7" },
        { "UnSexto", "Restar: 3/6 - 2/6" },
        { "SieteVeinte", "Restar: 3/5 - 1/4" },
        { "CuatroDecimos", "Restar: 2/2 - 3/5" },
        { "OchoVentiCuatro", "Restar: 2/4 - 1/6" },
        { "VeinteDieciseis", "Restar: 3/2 - 2/8" },
        { "TresSeptimos", "Restar: 4/7 - 1/7" },
        { "DoceDoce", "Restar: 3/2 - 3/6" },
        { "TresDos", "Restar: 5/2 - 2/2" }

};
    public List<Pregunta> preguntas = new List<Pregunta>()
{
    new Pregunta("Restar: 3/4 - 1/2", "DosOcho"),
    new Pregunta("Restar: 2/5 - 1/3", "UnoQuince"),
    new Pregunta("Restar: 1/4 - 1/7", "TresVentiOcho"),
    new Pregunta("Restar: 2/6 - 1/5", "CuatroTreinta"),
    new Pregunta("Restar: 3/4 - 2/4", "UnCuarto"),
    new Pregunta("Restar: 2/5 - 1/5", "UnQuinto"),
    new Pregunta("Restar: 1/2 - 1/8", "SeisDieciseis"),
    new Pregunta("Restar: 2/3 - 2/7", "OchoVentiUno"),
    new Pregunta("Restar: 3/6 - 2/6", "UnSexto"),
    new Pregunta("Restar: 3/5 - 1/4", "SieteVeinte"),
    new Pregunta("Restar: 2/2 - 3/5", "CuatroDecimos"),
    new Pregunta("Restar: 2/4 - 1/6", "OchoVentiCuatro"),
    new Pregunta("Restar: 3/2 - 2/8", "VeinteDieciseis"),
    new Pregunta("Restar: 4/7 - 1/7", "TresSeptimos"),
    new Pregunta("Restar: 3/2 - 3/6", "DoceDoce"),
    new Pregunta("Restar: 5/2 - 2/2", "TresDos"),

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
            EsferaRotator3 rotator = esfera.AddComponent<EsferaRotator3>();
            rotator.centro = centro;
            rotator.velocidadRotacion = velocidadRotacion;
        }

        for (int i = 0; i < cantidadEsferasOrbita2; i++)
        {
            float angulo = i * (360f / cantidadEsferasOrbita2);
            Vector3 posicion = centro + Quaternion.Euler(0, 0, angulo) * Vector3.right * radioOrbita2;
            GameObject esfera = Instantiate(esferaPrefab[cantidadEsferasOrbita1 + i], posicion, Quaternion.identity);
            esfera.transform.SetParent(transform);

            EsferaRotator3 rotator = esfera.AddComponent<EsferaRotator3>();
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
public class EsferaRotator3 : MonoBehaviour
{
    public Vector3 centro;
    public float velocidadRotacion;
    void Update()
    {
        transform.RotateAround(centro, Vector3.forward, velocidadRotacion * Time.deltaTime);
    }
}
