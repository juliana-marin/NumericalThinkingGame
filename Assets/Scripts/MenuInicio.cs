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
    public void Jugar(int indiceNivel)
    {
        SceneManager.LoadScene(indiceNivel);
        Time.timeScale = 1;
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
