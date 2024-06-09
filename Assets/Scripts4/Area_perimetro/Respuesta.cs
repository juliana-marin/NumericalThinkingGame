using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespuestaArea : MonoBehaviour
{ 
   public AreaPerimetro generador;
   public int respuestaa;
   public int respuestab;
   public int respuestac;
   public bool colision = false;
   public int idRespuesta;

    // Método para guardar resultados en variables aleatorias
    public int[] GuardarResultadosAleatorios( int resultadoA, int resultadoB, int resultadoC)
    {
        int[] resultados = new int[] { resultadoA, resultadoB, resultadoC };
        Shuffle(resultados); // Mezcla el arreglo de resultados

        return resultados;
    }
    private void Shuffle(int[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //colision = true;
            generador.id = idRespuesta;

            GameObject collidedObject = collision.gameObject;
        }
    }
    
}
