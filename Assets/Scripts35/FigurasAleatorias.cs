using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FigurasAleatorias : MonoBehaviour
{
    public List<Sprite> sprites; // Lista de sprites de las figuras geométricas
    
     public float minY = 4f; // Límite inferior de la posición Y
    public float maxY = 5f; // Límite superior de la posición Y
    public float minX = -8f; // Límite inferior de la posición X
    public float maxX = 8f; // Límite superior de la posición X
    public float spacing = 1f; // Espaciado entre las figuras

    void Start()
    {
        GenerarFigurasAleatorias();
    }

    void GenerarFigurasAleatorias()
    {
        // Crear una lista de índices aleatorios
        List<int> indicesAleatorios = new List<int>();
        for (int i = 0; i < sprites.Count; i++)
        {
            indicesAleatorios.Add(i);
        }
        indicesAleatorios = ShuffleList(indicesAleatorios);

        float totalWidth = 0f;
        foreach (int indice in indicesAleatorios)
        {
            Sprite sprite = sprites[indice];
            totalWidth += sprite.bounds.size.x + spacing;
        }

        totalWidth -= spacing; // Restar el último espaciado

        float startX = -totalWidth / 2f; // Calcular la posición inicial en X

        foreach (int indice in indicesAleatorios)
        {
            Sprite sprite = sprites[indice];
            float posX = startX + sprite.bounds.size.x / 2f;
            float posY = Random.Range(minY, maxY);

            GameObject figura = new GameObject(); // Crea un nuevo objeto para la figura
            figura.transform.position = new Vector2(posX, posY); // Asigna la posición
            figura.AddComponent<SpriteRenderer>().sprite = sprite; // Asigna el sprite

            startX += sprite.bounds.size.x + spacing; // Actualizar la posición inicial para la siguiente figura
        }
    }

    // Función para mezclar una lista de índices
    List<int> ShuffleList(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
        return list;
    }
}
