/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarPregunta : MonoBehaviour
{
  public Text textoPregunta; // Referencia al componente de texto

    // Método para actualizar el texto con la pregunta
    public void ActualizarTexto(string nuevaPregunta)
    {
        textoPregunta.text = nuevaPregunta;
    }
}*/
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MostrarPregunta1 : MonoBehaviour
{
    public Text textoPregunta; // Referencia al componente de texto

    // Método para actualizar el texto con la pregunta y las respuestas
    public void ActualizarTexto(string nuevaPregunta, string [] nuevasRespuestas)
    {
        string textoCompleto = nuevaPregunta + "\n"; // Agregar la pregunta al texto con un salto de línea
        char letraRespuesta = 'A';
        // Agregar las respuestas al texto
        for (int i = 0; i < nuevasRespuestas.Length; i++)
        {
            textoCompleto += letraRespuesta + ") " + nuevasRespuestas[i] + "\n";
            letraRespuesta++; // Incrementar la letra de la respuesta
        }

        // Mostrar el texto formateado en el objeto de texto
        textoPregunta.text = textoCompleto;
    }
    public void texto(String text)
    {
        textoPregunta.text = text;
    }
}

