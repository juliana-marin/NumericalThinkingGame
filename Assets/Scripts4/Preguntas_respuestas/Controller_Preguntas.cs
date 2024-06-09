using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Controller : MonoBehaviour
{
    public AudioSource clip;
    public AudioSource clip2;
    public AudioSource clip3;
    public int id;
    //public GameObject objetoObjetivo;
    //public AccionObjetivo accionObjetivo;
    //public GameObject caja;
    public Jugador player;
    public Respuesta respuesta1;
    public Respuesta respuesta2;
    public Respuesta respuesta3;
    private Respuesta respuesta;
    public MostrarPregunta1 mostrarPregunta; // Referencia al script MostrarPregunta
    private string pregunta = "";
    //public PlatformMove script1;
    //public ControlFuego apagar;
    private bool esperandoRespuesta = false;
    private bool colision = false;
    private string respuestaUsuario;
    private bool respuestaGenerada = false;
    public preguntas GeneradorPreguntas;
    string [] respuestas = new string [3];
    string [] respuestasMezcladas = new string [2];
    private string respuestaCorrecta;
    public int preguntasCorrectas = 0;
    public QuestionManager Correctas;
    public GameObject r1;
    public GameObject r2;
    public GameObject r3;
    public ScoreManager puntaje;
    
    //Activa las variables colision y esperandoRespuesta luego de detectar una colision
     public void activarColision()
    {
        respuesta = new Respuesta();
        esperandoRespuesta = true;
        colision = true;
        clip.Play();
    }
    void Update()
    {
        if(colision){
            
            if(!respuestaGenerada)
            {
                QuestionData preguntaAleatoria = GeneradorPreguntas.GetRandomQuestion();

                respuestas = respuesta.GuardarResultadosAleatorios(preguntaAleatoria.correctAnswer, preguntaAleatoria.incorrectAnswer1, preguntaAleatoria.incorrectAnswer2);

                mostrarPregunta.ActualizarTexto(preguntaAleatoria.question, respuestas );
                r1.SetActive(true);
                r2.SetActive(true);
                r3.SetActive(true);
                respuestaGenerada = true;
                respuestaCorrecta = preguntaAleatoria.correctAnswer;

                respuesta1.respuestaa = respuestas[0];
                respuesta2.respuestab = respuestas[1];
                respuesta3.respuestac = respuestas[2];
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
            if (respuestaUsuario == respuestaCorrecta)
            {
                clip2.Play();
                //caja.SetActive(false);
                Correctas.aumentar();
                puntaje.QuestionAnsweredCorrectly();
               
                /*switch (accionObjetivo)
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
                }*/
                
                mostrarPregunta.texto("Respuesta correcta.");
                GetComponent<BoxCollider2D>().enabled = false;
                colision = false;
                player.colision = false;
                respuestaGenerada = false;
            }
            else
            {
                clip3.Play();
                PlayerHealthController.instance.DealDamage();
                mostrarPregunta.texto("Respuesta incorrecta.");
                respuestaGenerada = false;
                colision = false;
                player.colision = false;
            }
            esperandoRespuesta = false; // No esperar más respuestas
            respuestaGenerada = false;
            player.colision = false;
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


