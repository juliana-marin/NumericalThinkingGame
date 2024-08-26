using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaActivable : MonoBehaviour
{
    public PlatformMove script1;
    private string inputBuffer = "";
    private void Start()
    {
        if (script1 == null)
        {
            script1 = GetComponent<PlatformMove>();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            float.TryParse(inputBuffer, out float nuevoValor);
            if (nuevoValor == 2)
            {
                script1.speed = nuevoValor;
                Debug.Log("El valor de speed se ha cambiado a: " + nuevoValor);
            }
            else
            {
                Debug.LogError("El valor ingresado no es válido.");
            }
            inputBuffer = "";
        }
        else
        {
            inputBuffer += Input.inputString;
        }
    }
}



