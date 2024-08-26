using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicForma : MonoBehaviour
{
    private string respuestaSeleccionada;
    private string respuestaCorrecta;
    private void OnMouseDown()
    {
        string nombreFigura = gameObject.name;

        if (Controlador.nombreFiguraRespuesta.ContainsKey(nombreFigura))
        {
            respuestaCorrecta = Controlador.nombreFiguraRespuesta[nombreFigura];
            SeleccionarRespuesta(nombreFigura);
            if (respuestaSeleccionada == respuestaCorrecta)
            {
                GetComponent<SpriteRenderer>().color = Color.green;
            }
            else
            {
                Debug.Log("Respuesta incorrecta " + gameObject.name);
            }
            Controlador controlador = FindObjectOfType<Controlador>();
            controlador.GenerarPreguntaAleatoria();
        }
    }
    public void SeleccionarRespuesta(string respuesta)
    {
        respuestaSeleccionada = respuesta;
        Debug.Log("Figura seleccionada: " + respuestaSeleccionada);

        Controlador controlador = FindObjectOfType<Controlador>();
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
