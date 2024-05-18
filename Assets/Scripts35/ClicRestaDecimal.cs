using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicRestaDecimal : MonoBehaviour
{
    private string respuestaSeleccionada; // Variable para almacenar la respuesta seleccionada por el jugador
 private string respuestaCorrecta;
 


   private void OnMouseDown()
    {






        string nombreFigura = gameObject.name;

        
            if (GeneradorRestaDecimal.nombreFiguraRespuesta.ContainsKey(nombreFigura))
            {
                respuestaCorrecta = GeneradorRestaDecimal.nombreFiguraRespuesta[nombreFigura];
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
                 GeneradorRestaDecimal controlador = FindObjectOfType<GeneradorRestaDecimal>(); // Encuentra una instancia de Controlador en la escena
                controlador.GenerarPreguntaAleatoria();
            }
        }
        


 // Método para asignar la respuesta seleccionada por el jugador
    public void SeleccionarRespuesta(string respuesta)
{
   respuestaSeleccionada = respuesta;
        Debug.Log("Figura seleccionada: " + respuestaSeleccionada);

        GeneradorRestaDecimal controlador = FindObjectOfType<GeneradorRestaDecimal>();
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
