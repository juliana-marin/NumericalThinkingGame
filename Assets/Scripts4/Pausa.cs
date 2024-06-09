using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{   
    public GameObject optionPanel;
    public GameObject Audio;
    public void pausar()
    {
        Time.timeScale = 0;
        optionPanel.SetActive(true);
        Audio.SetActive(false);
    }
    public void reanudar()
    {
        Time.timeScale = 1;
        optionPanel.SetActive(false); 
        Audio.SetActive(true);
    }
    public void cambiarScena(int indiceNivel)
    {
        SceneManager.LoadScene(indiceNivel);
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
     public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
