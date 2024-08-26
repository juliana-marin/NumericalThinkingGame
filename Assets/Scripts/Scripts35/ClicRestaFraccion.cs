using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicRestaFraccion : MonoBehaviour
{
    private string respuestaSeleccionada; 
    private string respuestaCorrecta;
    private void OnMouseDown()
    {
        string nombreFigura = gameObject.name;

        if (GeneradorRestaFraccion.nombreFiguraRespuesta.ContainsKey(nombreFigura))
        {
            respuestaCorrecta = GeneradorRestaFraccion.nombreFiguraRespuesta[nombreFigura];
            SeleccionarRespuesta(nombreFigura);

            if (respuestaSeleccionada == respuestaCorrecta)
            {
                Debug.Log("Respuesta seleccionada: " + nombreFigura + ", Respuesta correcta: " + respuestaCorrecta);
                GetComponent<SpriteRenderer>().color = Color.green;
            }
            else
            {
                Debug.Log("Respuesta incorrecta " + gameObject.name);
            }
            GeneradorRestaFraccion controlador = FindObjectOfType<GeneradorRestaFraccion>();
            controlador.GenerarPreguntaAleatoria();
        }
    }

    public void SeleccionarRespuesta(string respuesta)
    {
        respuestaSeleccionada = respuesta;
        Debug.Log("Figura seleccionada: " + respuestaSeleccionada);

        GeneradorRestaFraccion controlador = FindObjectOfType<GeneradorRestaFraccion>();
        bool respuestaCorrecta = controlador.VerificarRespuesta(respuestaSeleccionada, gameObject.name);
        if (respuestaCorrecta)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
    void Start()
    {

    }
    void Update()
    {

    }
}