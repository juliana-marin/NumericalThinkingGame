using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MostrarPregunta : MonoBehaviour
{
    public Text textoPregunta;
    public void ActualizarTexto(string nuevaPregunta, int[] nuevasRespuestas)
    {
        string textoCompleto = nuevaPregunta + "\n";
        char letraRespuesta = 'A';
        for (int i = 0; i < nuevasRespuestas.Length; i++)
        {
            textoCompleto += letraRespuesta + ") " + nuevasRespuestas[i] + "\n";
            letraRespuesta++;
        }
        textoPregunta.text = textoCompleto;
    }
    public void texto(String text)
    {
        textoPregunta.text = text;
    }
}

