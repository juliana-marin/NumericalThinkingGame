using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CambiadorDeSpeed : MonoBehaviour
{
    public PlatformMove script1;
   

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag( "Player"))
        {
            script1.speed = 3.0f; // Cambia el valor de speed al nuevo valor deseado
           // activado = true; // Marca como activado para evitar cambios repetidos
            Debug.Log("Se ha activado el cambio de velocidad.");
        }
    }
}