using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FigurasAleatorias : MonoBehaviour
{
    public List<Sprite> sprites;
    public float minY = 4f;
    public float maxY = 5f;
    public float minX = -8f;
    public float maxX = 8f;
    public float spacing = 1f;

    void Start()
    {
        GenerarFigurasAleatorias();
    }

    void GenerarFigurasAleatorias()
    {
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

        totalWidth -= spacing;

        float startX = -totalWidth / 2f;

        foreach (int indice in indicesAleatorios)
        {
            Sprite sprite = sprites[indice];
            float posX = startX + sprite.bounds.size.x / 2f;
            float posY = Random.Range(minY, maxY);

            GameObject figura = new GameObject();
            figura.transform.position = new Vector2(posX, posY);
            figura.AddComponent<SpriteRenderer>().sprite = sprite;

            startX += sprite.bounds.size.x + spacing;
        }
    }
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
