using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaActivable : MonoBehaviour
{
    // Referencia al script que contiene la variable speed
    public PlatformMove script1;

    private string inputBuffer = ""; // Almacena la entrada del usuario

    private void Start()
    {
        // Si script1 no está asignado, intenta encontrarlo en el GameObject actual
        if (script1 == null)
        {
            script1 = GetComponent<PlatformMove>();
        }
    }

    private void Update()
    {
        // Verifica si se presionó la tecla Enter (Return)
        if (Input.GetKeyDown(KeyCode.Return))
        {
            float.TryParse(inputBuffer, out float nuevoValor);
            // Intenta convertir la entrada almacenada en inputBuffer a un float
            if (nuevoValor == 2)
            {
                // Cambia el valor de speed al nuevo valor ingresado por el usuario
                script1.speed = nuevoValor;
                Debug.Log("El valor de speed se ha cambiado a: " + nuevoValor);
            }
            else
            {
                Debug.LogError("El valor ingresado no es válido.");
            }

            // Limpia el buffer de entrada para la próxima entrada
            inputBuffer = "";
        }
        else
        {
            // Agrega la entrada del usuario al buffer de entrada
            inputBuffer += Input.inputString;
        }
    }
}



