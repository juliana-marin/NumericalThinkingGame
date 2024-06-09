using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPreguntas : MonoBehaviour
{
    private int lado1;
    private int lado2;
    private int lado3;
    private int numeroFigura;
    private int respuestaErronea;
    private int respuestaErronea1;
    //private int respuesta;
    public CalculadoraGeometrica areaPerimetro;
    public void OperacionMatematica(out string pregunta, out int respuesta, out int respuestaErronea, out int respuestaErronea1)
    {
        numeroFigura = Random.Range(1,9);
        // Realizar la operación basada en el símbolo de entrada
        switch (numeroFigura)
        {
            
            case 1:
                lado1 = Random.Range(10, 50);
                respuesta = areaPerimetro.CalcularAreaCuadrado(lado1);
                pregunta = $"Calcular el area del cuadrado de lado {lado1} ";
                respuestaErronea = respuesta + Random.Range(-10, 11); // Valor cercano a la respuesta correcta
                respuestaErronea1 = respuesta + Random.Range(-10, 11); // Otro valor cercano a la respuesta correcta
                break;
            
            case 2:
                lado1 = Random.Range(10,50);
                respuesta = areaPerimetro.CalcularPerimetroCuadrado(lado1);
                pregunta = $"¿Cuál es el perimetro del cuadrado de lado {lado1}?";
                respuestaErronea = respuesta + Random.Range(-10, 11); // Valor cercano a la respuesta correcta
                respuestaErronea1 = respuesta + Random.Range(-10, 11); // Otro valor cercano a la respuesta correcta
                break;
            
            case 3:
                do
                {
                    lado1 = Random.Range(10, 50);
                    lado2 = Random.Range(10, 50);
                } while (lado1 <= lado2); // Continuar generando hasta que lado1 sea mayor que lado2

                respuesta = areaPerimetro.CalcularAreaRectangulo(lado1, lado2);
                pregunta = $"¿Cuál es el área del rectángulo de base {lado1} y altura {lado2}?";
                respuestaErronea = respuesta + Random.Range(-10, 11); // Valor cercano a la respuesta correcta
                respuestaErronea1 = respuesta + Random.Range(-10, 11); // Otro valor cercano a la respuesta correcta
                break;
            case 4:
                do{
                    lado1 = Random.Range(10,50);
                    lado2 = Random.Range(10,50);
                } while(lado1 <= lado2);
                
                respuesta = areaPerimetro.CalcularPerimetroRectangulo(lado1, lado2);
                pregunta = $"¿Cuál es el perimetro del rectangulo de base {lado1} y altura {lado2} ?";
                respuestaErronea = respuesta + Random.Range(-10, 11); // Valor cercano a la respuesta correcta
                respuestaErronea1 = respuesta + Random.Range(-10, 11); // Otro valor cercano a la respuesta correcta
                break;
            case 5:
                lado1 = Random.Range(10, 50);
                lado2 = Random.Range(10, 50);
                respuesta = areaPerimetro.CalcularPerimetroTrianguloRectangulo(lado1, lado2);
                pregunta = $"¿Cuál es el perimetro del triangulo rectángulo de base {lado1} y altura {lado2}?";
                respuestaErronea = respuesta + Random.Range(-10, 11); // Valor cercano a la respuesta correcta
                respuestaErronea1 = respuesta + Random.Range(-10, 11); // Otro valor cercano a la respuesta correcta
                break;
            case 6:
                lado1 = Random.Range(10, 50);
                lado2 = Random.Range(10, 50);
                respuesta = areaPerimetro.CalcularAreaTriangulo(lado1, lado2);
                pregunta = $"¿Cuál es el área del triangulo rectángulo de base {lado1} y altura {lado2}?";
                respuestaErronea = respuesta + Random.Range(-10, 11); // Valor cercano a la respuesta correcta
                respuestaErronea1 = respuesta + Random.Range(-10, 11); // Otro valor cercano a la respuesta correcta
                break;
            case 7:
                lado1 = Random.Range(10, 50);
                respuesta = areaPerimetro.CalcularPerimetroCirculo(lado1);
                pregunta = $"¿Cuál es el perimetro del circulo de radio {lado1}?";
                respuestaErronea = respuesta + Random.Range(-10, 11); // Valor cercano a la respuesta correcta
                respuestaErronea1 = respuesta + Random.Range(-10, 11); // Otro valor cercano a la respuesta correcta
                break;
            case 8:
                lado1 = Random.Range(10, 50);
                respuesta = areaPerimetro.CalcularAreaCirculo(lado1);
                pregunta = $"¿Cuál es el area del circulo de radio {lado1}?";
                respuestaErronea = respuesta + Random.Range(-10, 11); // Valor cercano a la respuesta correcta
                respuestaErronea1 = respuesta + Random.Range(-10, 11); // Otro valor cercano a la respuesta correcta
                break;
                
            default:
                pregunta = "Operación no válida";
                respuesta = 0; // Asignar un valor predeterminado
                respuestaErronea = 0;
                respuestaErronea1 = 0;
                break;
        }
    }

}


