using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum AccionObjetivo
{
    CambiarVelocidad,
    Activar,
    Desactivar,
    Apagar
}

public class Sumas : MonoBehaviour
{
    public AudioSource clip;
    public AudioSource clip2;
    public AudioSource clip3;
    public int id;
    public GameObject objetoObjetivo;
    public AccionObjetivo accionObjetivo;
    public GameObject caja;
    public Jugador player;
    public Respuestas respuesta1;
    public Respuestas respuesta2;
    public Respuestas respuesta3;
    private Respuestas respuestas;
    public char simbolo = ' ';
    public GeneradorOperaciones suma;
    public MostrarPregunta mostrarPregunta; // Referencia al script MostrarPregunta
    private string pregunta = "";
    public PlatformMove script1;
    public ControlFuego apagar;
    private int sumaEsperada;
    private bool esperandoRespuesta = false;
    private bool colision = false;
    private bool sumaGenerada = false;
    public int respuestaUsuario;
    private int respuestaErronea;
    private int respuestaErronea1;
    int [] respuestasMezcladas = new int [2];
    public QuestionManager Correctas;
    public GameObject r1;
    public GameObject r2;
    public GameObject r3;
    public ScoreManager puntaje;
    
    //Activa las variables colision y esperandoRespuesta luego de detectar una colision
     public void activarColision()
    {
        respuestas = new Respuestas();
        esperandoRespuesta = true;
        colision = true;
        clip.Play();
    }
    void Update()
    {
        if(colision){
            
            if(!sumaGenerada)
            {
                suma.OperacionMatematica(simbolo, out pregunta, out sumaEsperada, out respuestaErronea,  out respuestaErronea1 );
                
                respuestasMezcladas = respuestas.GuardarResultadosAleatorios(sumaEsperada, respuestaErronea1, respuestaErronea);
                
                mostrarPregunta.ActualizarTexto(pregunta, respuestasMezcladas );
                
                sumaGenerada = true;

                r1.SetActive(true);
                r2.SetActive(true);
                r3.SetActive(true);

                respuesta1.respuestaa = respuestasMezcladas[0];
                respuesta2.respuestab = respuestasMezcladas[1];
                respuesta3.respuestac = respuestasMezcladas[2];
            } 
        }
        if (esperandoRespuesta && player.colision)
        {
            if(id == 1)
            {
                respuestaUsuario = respuesta1.respuestaa;
            }
            if(id == 2)
            {
                respuestaUsuario = respuesta2.respuestab;
            }
            if(id == 3)
            {
                respuestaUsuario = respuesta3.respuestac;
            }
            if (respuestaUsuario == sumaEsperada)
            {
                clip2.Play();
                //caja.SetActive(false);
                Correctas.aumentar();
                puntaje.QuestionAnsweredCorrectly();
                switch (accionObjetivo)
                {
                    case AccionObjetivo.CambiarVelocidad:
                        // Cambiar la velocidad del objeto objetivo
                        script1.speed = 3;
                        break;
                    case AccionObjetivo.Activar:
                        // Activar el objeto objetivo
                        objetoObjetivo.SetActive(true);
                        break;
                    case AccionObjetivo.Desactivar:
                        // Desactivar el objeto objetivo
                        objetoObjetivo.SetActive(false);
                        break;
                    case AccionObjetivo.Apagar:
                        apagar.activar = false;
                        break;
                }
                
                mostrarPregunta.texto("Respuesta correcta.");
                colision = false;
                player.colision = false;
                sumaGenerada = false;
            }
            else
            {
                clip3.Play();
                PlayerHealthController.instance.DealDamage();
                mostrarPregunta.texto("Respuesta incorrecta.");
                sumaGenerada = false;
                colision = false;
                player.colision = false;
            }
            esperandoRespuesta = false; // No esperar más respuestas
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            // Activar la espera de respuesta cuando se detecta la colisión
            activarColision();
        }   
    }
}


