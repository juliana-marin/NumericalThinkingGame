using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectsController : MonoBehaviour
{
    public Vector3[] posiciones;
    public GameObject[] objetos;
    public static ObjectsController instance;
    private List<Vector3> posicionesUtilizadas = new List<Vector3>();
    void Awake ()
    {
        instance = this;
    }

    public void generadorObjetos(Items item, int cantElements)
    {
        for(int i = 0; i < objetos.Length; ++ i)
        {
            if(objetos[i].name == item.ToString())
            {
                for(int index = 0; index < cantElements; ++ index)
                {
                    GameObject objetoSeleccionado = objetos[i];
                    Vector3 posicionSeleccionada = ObtenerPosicionAleatoria();
                    Instantiate(objetoSeleccionado, posicionSeleccionada, Quaternion.identity);
                }   
            }
        }
            
    }

    public Vector3 ObtenerPosicionAleatoria()
    {
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
        }
        return posicionAleatoria;
    }  

}
