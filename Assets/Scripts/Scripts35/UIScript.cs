using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIScript : MonoBehaviour
{
    public Text textoMultiplicacion;
    public void ActualizarTextoMultiplicacion(int factor1, int factor2)
    {
        textoMultiplicacion.text = $"{factor1} * {factor2} = ?";
    }
    public void ActualizarTextoResultado(int resultado)
    {
    }
    void Start()
    {

    }
    void Update()
    {

    }
}
