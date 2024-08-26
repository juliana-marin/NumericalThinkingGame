using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respuesta : MonoBehaviour
{ 
   public Controller generador;
   public string respuestaa;
   public string respuestab;
   public string respuestac;
   public bool colision = false;
   public int idRespuesta;
    public string[] GuardarResultadosAleatorios( string resultadoA, string resultadoB, string resultadoC)
    {
        string[] resultados = new string[] { resultadoA, resultadoB, resultadoC };
        Shuffle(resultados);

        return resultados;
    }
    private void Shuffle(string[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            string temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            generador.id = idRespuesta;
            GameObject collidedObject = collision.gameObject;
        }
    }
    
}
