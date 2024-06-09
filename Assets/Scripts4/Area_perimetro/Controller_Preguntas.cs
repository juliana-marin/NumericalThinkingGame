using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum Accion
{
    CambiarVelocidad,
    Activar,
    Desactivar,
    Apagar
}

public class AreaPerimetro : MonoBehaviour
{
    public AudioSource clip;
    public AudioSource clip2;
    public AudioSource clip3;
    public int id;
    public GameObject objetoObjetivo;
    public Accion accionObjetivo;
    //public GameObject caja;
    public Jugador player;
    public RespuestaArea respuesta1;
    public RespuestaArea respuesta2;
    public RespuestaArea respuesta3;
    private RespuestaArea respuesta;
    public MostrarPregunta mostrarPregunta; // Referencia al script MostrarPregunta
    private string pregunta = "";
    //public PlatformMove script1;
    //public ControlFuego apagar;
    private bool esperandoRespuesta = false;
    private bool colision = false;
    private int respuestaUsuario;
    private bool respuestaGenerada = false;
    public GeneradorPreguntas Generador;
    int [] respuestas = new int [3];
    string [] respuestasMezcladas = new string [2];
    private string respuestaCorrecta;
    private int respuestaErronea;
    private int respuestaErronea1;
    private int respuestaEsperada;
    public QuestionManager respuestasCorrectas;
    public ControlFuego apagar;
    public GameObject r1;
    public GameObject r2;
    public GameObject r3;
    public ScoreManager puntaje;
    
    //Activa las variables colision y esperandoRespuesta luego de detectar una colision
     public void activarColision()
    {
        respuesta = new RespuestaArea();
        esperandoRespuesta = true;
        colision = true;
        clip.Play();
    }
    void Update()
    {
        if(colision){
            
            if(!respuestaGenerada)
            {
                Generador.OperacionMatematica(out pregunta, out respuestaEsperada, out respuestaErronea, out respuestaErronea1);

                respuestas = respuesta.GuardarResultadosAleatorios(respuestaEsperada, respuestaErronea, respuestaErronea1);

                mostrarPregunta.ActualizarTexto(pregunta, respuestas);
                respuestaGenerada = true;

                r1.SetActive(true);
                r2.SetActive(true);
                r3.SetActive(true);

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
            if (respuestaUsuario == respuestaEsperada)
            {
                clip2.Play();
                respuestasCorrectas.aumentar();
                puntaje.QuestionAnsweredCorrectly();
                
                switch (accionObjetivo)
                {
                    case Accion.CambiarVelocidad:
                        // Cambiar la velocidad del objeto objetivo
                        //script1.speed = 3;
                        break;
                    case Accion.Activar:
                        // Activar el objeto objetivo
                        objetoObjetivo.SetActive(true);
                        break;
                    case Accion.Desactivar:
                        // Desactivar el objeto objetivo
                        objetoObjetivo.SetActive(false);
                        break;
                    case Accion.Apagar:
                        apagar.activar = false;
                        break;
                }
                
                mostrarPregunta.texto("Respuesta correcta.");
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


