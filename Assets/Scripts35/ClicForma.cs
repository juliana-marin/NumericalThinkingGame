using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicForma : MonoBehaviour
{
 private string respuestaSeleccionada; // Variable para almacenar la respuesta seleccionada por el jugador
 private string respuestaCorrecta;
 


   private void OnMouseDown()
    {

          // Lanzar un rayo desde la posición del clic hacia el collider de la forma
//    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

    // Verificar si el rayo impacta con el collider de la forma
//    if (hit.collider != null && hit.collider.gameObject == gameObject)
//    {
//        Debug.Log("Se ha hecho clic en la forma " + gameObject.name);
//    }


        string nombreFigura = gameObject.name;
        

       if (Controlador.nombreFiguraRespuesta.ContainsKey(nombreFigura))
{

     respuestaCorrecta = Controlador.nombreFiguraRespuesta[nombreFigura];
    // Controlador controlador = FindObjectOfType<Controlador>(); // Encuentra una instancia de Controlador en la escena
       SeleccionarRespuesta(nombreFigura); // Llama al método SeleccionarRespuesta del Controlador y pasa la respuesta correcta

   
   if (respuestaSeleccionada == respuestaCorrecta)
    {
         Debug.Log("Respuesta seleccionada222: " + nombreFigura + ", Respuesta correcta: " + respuestaCorrecta);
        // Cambiar el color de la figura si la respuesta es correcta
        GetComponent<SpriteRenderer>().color = Color.green;
      //  Debug.Log("Se ha hecho clic en la forma correcta " + gameObject.name);
       // SeleccionarRespuesta(respuestaCorrecta);
    }
    else
            {
                Debug.Log("Respuesta incorrecta " + gameObject.name);
            }
    // Generar una nueva pregunta al detectar un clic
            Controlador controlador = FindObjectOfType<Controlador>(); // Encuentra una instancia de Controlador en la escena
            controlador.GenerarPreguntaAleatoria();
}
    }

 // Método para asignar la respuesta seleccionada por el jugador
    public void SeleccionarRespuesta(string respuesta)
{
    respuestaSeleccionada = respuesta;
    Debug.Log("Figura seleccionada: " + respuestaSeleccionada);

    Controlador controlador = FindObjectOfType<Controlador>();
    bool respuestaCorrecta =controlador.VerificarRespuesta(respuestaSeleccionada, gameObject.name); // Pasar el nombre de la figura seleccionada
if (respuestaCorrecta)
    {
        // Cambiar el color de la figura si la respuesta es correcta
        GetComponent<SpriteRenderer>().color = Color.green;
       
    }

}


//    private void OnMouseDown()
//    {
        // Cambiar el color de la forma al hacer clic
//        GetComponent<SpriteRenderer>().color = Color.black;
//    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
