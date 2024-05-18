using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicTercero : MonoBehaviour
{
    private string respuestaSeleccionada; // Variable para almacenar la respuesta seleccionada por el jugador
 private string respuestaCorrecta;
 


   private void OnMouseDown()
    {






        string nombreFigura = gameObject.name;

        
            if (ControlTerceroDecimal.nombreFiguraRespuesta.ContainsKey(nombreFigura))
            {
                respuestaCorrecta = ControlTerceroDecimal.nombreFiguraRespuesta[nombreFigura];
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
                 ControlTerceroDecimal controlador = FindObjectOfType<ControlTerceroDecimal>(); // Encuentra una instancia de Controlador en la escena
                controlador.GenerarPreguntaAleatoria();
            }
        }
        


 // Método para asignar la respuesta seleccionada por el jugador
    public void SeleccionarRespuesta(string respuesta)
{
   respuestaSeleccionada = respuesta;
        Debug.Log("Figura seleccionada: " + respuestaSeleccionada);

        ControlTerceroDecimal controlador = FindObjectOfType<ControlTerceroDecimal>();
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

