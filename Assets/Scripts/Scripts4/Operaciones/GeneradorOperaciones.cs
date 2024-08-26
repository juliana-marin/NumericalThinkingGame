using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorOperaciones : MonoBehaviour
{
    public int minimo = 1;
    public int maximo = 999;
    private int numero1;
    private int numero2;
    private int respuestaErronea;
    private int respuestaErronea1;
    public void OperacionMatematica(char simbolo, out string operacion, out int respuesta, out int respuestaErronea, out int respuestaErronea1)
    {
        numero1 = Random.Range(minimo, maximo + 1);
        numero2 = Random.Range(minimo, maximo + 1);
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
                    numero2 = Random.Range(1, maximo + 1);
                    int multiplicador = Random.Range(1, maximo + 1);
                    numero1 = numero2 * multiplicador;
                } while (numero2 == 0);
                    respuesta = numero1 / numero2;
                    operacion = $"¿Cuánto es {numero1} / {numero2}?";
                    respuestaErronea = RespuestaErronea(respuesta);
                    respuestaErronea1 = RespuestaErronea(respuesta);
                break;
            default:
                operacion = "Operación no válida";
                respuesta = 0;
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
        } while (respuestaErronea == respuestaCorrecta);

        return respuestaErronea;
    }

}


