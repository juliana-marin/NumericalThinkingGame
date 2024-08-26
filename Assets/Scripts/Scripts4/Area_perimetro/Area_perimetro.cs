using UnityEngine;

public class CalculadoraGeometrica : MonoBehaviour
{
    public int CalcularPerimetroCuadrado(int lado)
    {
        return 4 * lado;
    }
    public int CalcularAreaCuadrado(int lado)
    {
        return lado * lado;
    }
    public int CalcularPerimetroRectangulo(int baseRectangulo, int alturaRectangulo)
    {
        return 2 * (baseRectangulo + alturaRectangulo);
    }
    public int CalcularAreaRectangulo(int baseRectangulo, int alturaRectangulo)
    {
        return baseRectangulo * alturaRectangulo;
    }
    public int CalcularPerimetroTrianguloRectangulo(int baseRect, int altura)
    {
        int hipotenusa = (int)Mathf.Sqrt(baseRect * baseRect + altura * altura);
        return baseRect + altura + hipotenusa;
    }
    public int CalcularAreaTriangulo(int baseTriangulo, int alturaTriangulo)
    {
        return (baseTriangulo * alturaTriangulo) / 2;
    }
    public float CalcularPerimetroRombo(float lado)
    {
        return 4 * lado;
    }

    public float CalcularAreaRombo(float diagonalMayor, float diagonalMenor)
    {
        return (diagonalMayor * diagonalMenor) / 2;
    }

    public int CalcularPerimetroCirculo(int radio)
    {
        return (int)(2 * Mathf.PI * radio);
    }
    public int CalcularAreaCirculo(int radio)
    {
        return (int)(Mathf.PI * radio * radio);
    }
}
