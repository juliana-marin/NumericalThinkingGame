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
        // Implementa aquí la lógica para actualizar el texto del resultado en la UI
    }













    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
