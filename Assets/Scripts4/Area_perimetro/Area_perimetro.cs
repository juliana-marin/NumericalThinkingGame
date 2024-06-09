using UnityEngine;

public class CalculadoraGeometrica : MonoBehaviour
{
    // Calcula el perímetro de un cuadrado dado el lado
    public int CalcularPerimetroCuadrado(int lado)
    {
        return 4 * lado;
    }

    // Calcula el área de un cuadrado dado el lado
    public int CalcularAreaCuadrado(int lado)
    {
        return lado * lado;
    }

    // Calcula el perímetro de un rectángulo dado la base y la altura
    public int CalcularPerimetroRectangulo(int baseRectangulo, int alturaRectangulo)
    {
        return 2 * (baseRectangulo + alturaRectangulo);
    }

    // Calcula el área de un rectángulo dado la base y la altura
    public int CalcularAreaRectangulo(int baseRectangulo, int alturaRectangulo)
    {
        return baseRectangulo * alturaRectangulo;
    }

    // Calcula el perímetro de un triángulo dado los tres lados
    public int CalcularPerimetroTrianguloRectangulo(int baseRect, int altura)
    {
        // Hipotenusa
        int hipotenusa = (int)Mathf.Sqrt(baseRect * baseRect + altura * altura);
        return baseRect + altura + hipotenusa;
    }

    // Calcula el área de un triángulo dado la base y la altura
    public int CalcularAreaTriangulo(int baseTriangulo, int alturaTriangulo)
    {
        return (baseTriangulo * alturaTriangulo) / 2;
    }

    // Calcula el perímetro de un rombo dado la longitud del lado
    public float CalcularPerimetroRombo(float lado)
    {
        return 4 * lado;
    }

    // Calcula el área de un rombo dado las longitudes de las diagonales
    public float CalcularAreaRombo(float diagonalMayor, float diagonalMenor)
    {
        return (diagonalMayor * diagonalMenor) / 2;
    }

    // Calcula el perímetro de un círculo dado el radio
    public int CalcularPerimetroCirculo(int radio)
    {
        return (int)(2 * Mathf.PI * radio);
    }

    // Calcula el área de un círculo dado el radio
    public int CalcularAreaCirculo(int radio)
    {
        return (int)(Mathf.PI * radio * radio);
    }
}
