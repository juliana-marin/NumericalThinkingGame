using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorOperaciones : MonoBehaviour
{
    public int minimo = 1; // Valor mínimo para los números aleatorios
    public int maximo = 999; // Valor máximo para los números aleatorios
    private int numero1;
    private int numero2;
    private int respuestaErronea;
    private int respuestaErronea1;
    public void OperacionMatematica(char simbolo, out string operacion, out int respuesta, out int respuestaErronea, out int respuestaErronea1)
    {
        // Generar dos números aleatorios para la operación
        numero1 = Random.Range(minimo, maximo + 1);
        numero2 = Random.Range(minimo, maximo + 1);
    

        // Realizar la operación basada en el símbolo de entrada
        switch (simbolo)
        {
            case '+':
                respuesta = numero1 + numero2;
                operacion = $"¿Cuánto es {numero1} + {numero2}?";
                respuestaErronea = RespuestaErronea(respuesta);
                respuestaErronea1 = RespuestaErronea(respuesta);
                break;
            case '-':
                do
                {
                    numero1 = Random.Range(minimo, maximo + 1);
                    numero2 = Random.Range(minimo, maximo + 1);
                    
                }while(numero1 < numero2);
                
                    respuesta = numero1 - numero2;
                    operacion = $"¿Cuánto es {numero1} - {numero2}?";
                    respuestaErronea = RespuestaErronea(respuesta);
                    respuestaErronea1 = RespuestaErronea(respuesta);
                break;   
            case '*':
                respuesta = numero1 * numero2;
                operacion = $"¿Cuánto es {numero1} * {numero2}?";
                respuestaErronea = RespuestaErronea(respuesta);
                respuestaErronea1 = RespuestaErronea(respuesta);
                break;
            case '/':
                do
                {
                    numero2 = Random.Range(1, maximo + 1); // numero2 no debe ser cero
                    int multiplicador = Random.Range(1, maximo + 1);
                    numero1 = numero2 * multiplicador; // Asegurar que numero1 es un múltiplo de numero2
                } while (numero2 == 0);
                    respuesta = numero1 / numero2;
                    operacion = $"¿Cuánto es {numero1} / {numero2}?";
                    respuestaErronea = RespuestaErronea(respuesta);
                    respuestaErronea1 = RespuestaErronea(respuesta);
                break;
            default:
                operacion = "Operación no válida";
                respuesta = 0; // Asignar un valor predeterminado
                respuestaErronea = 0;
                respuestaErronea1 = 0;
                break;

                
        }
    }

    private int RespuestaErronea(int respuestaCorrecta)
    {
        int respuestaErronea;
        do
        {
            respuestaErronea = respuestaCorrecta + Random.Range(-10, 11);
        } while (respuestaErronea == respuestaCorrecta); // Asegurarse de que no sea igual a la respuesta correcta

        return respuestaErronea;
    }

}


