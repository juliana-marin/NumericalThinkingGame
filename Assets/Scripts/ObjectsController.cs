using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectsController : MonoBehaviour
{
    public Vector3[] posiciones;
    public GameObject[] objetos;
    public AudioClip sonidoObjeto;
    public static ObjectsController instance;
    private List<Vector3> posicionesUtilizadas = new List<Vector3>();
    void Awake ()
    {
        instance = this;
    }


    public void GenerarObjetos(Items item, int cantElements)
    {
        StartCoroutine(GenerarObjetosCorutina(item, cantElements));
    }

    public IEnumerator GenerarObjetosCorutina(Items item, int cantElements)
    {
        GameObject objetoSeleccionado = null;
        for (int i = 0; i < objetos.Length; ++i)
        {
            if (objetos[i].name == item.ToString())
            {
                objetoSeleccionado = objetos[i];
                break;
            }
        }
        if (objetoSeleccionado == null)
        {
            yield break;
        }

        int maxObjectsPerFrame = 10;
        int generatedCount = 0;

        for (int index = 0; index < cantElements; ++index)
        {
            if (generatedCount >= maxObjectsPerFrame)
            {
                yield return null; 
                generatedCount = 0;
            }

            Vector3 posicionSeleccionada = ObtenerPosicionAleatoria();
            GameObject gameObject = Instantiate(objetoSeleccionado, posicionSeleccionada, Quaternion.identity);

            ObjectCont objectCont = gameObject.GetComponent<ObjectCont>();
            if (objectCont != null)
            {
                objectCont.sonidoObjeto = sonidoObjeto;
            }
            generatedCount++;
        }
    }

    public Vector3 ObtenerPosicionAleatoria()
    {
        if (posiciones.Length == 0) return Vector3.zero;

        Vector3 posicionAleatoria = Vector3.zero;
        bool posicionValida = false;

        while (!posicionValida)
        {
            posicionAleatoria = posiciones[Random.Range(0, posiciones.Length)];

            if (!posicionesUtilizadas.Contains(posicionAleatoria))
            {
            posicionesUtilizadas.Add(posicionAleatoria);
            posicionValida = true;
            }
        
            if (posicionesUtilizadas.Count >= posiciones.Length)
            {
                Debug.LogWarning("No hay posiciones válidas disponibles.");
                break;
            }   
        }   
        return posicionAleatoria;
    }  

}
