using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    
    public static MenuInicio instance;
    void Awake ()
    {
        instance = this;
    }
    //El parametro indiceNivel indica el numero de indice de la escena a donde quiero ir
    public void Jugar(int indiceNivel)
    {
        SceneManager.LoadScene(indiceNivel);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   public void Salir()
    {
        Application.Quit();
    }
}
