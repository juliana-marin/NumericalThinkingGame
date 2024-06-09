using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Objects
{ 
    public Items items_1;
    public Items items_2;
    public Operacion operacion;
    public int elementsMin;
    public int elementsMax;

}

public enum Items
{   
    Ninguno,
    Manzanas,
    Espadas,
    Abejas,
    Sombrillas,
    Banderas,
    Estrellas,
    Ranas
}

public enum Operacion
{
    Ninguno,
    Adición,
    Sustracción
}