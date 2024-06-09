using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Collections;
using System;

public class CambioDeNivel : MonoBehaviour
{
    public AudioSource clip;
    private bool nivelCambiado = false;
    public GameObject optionPanel;
    public GameObject Audio;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            clip.Play();
            StartCoroutine(CambiarNivelDespuesDeSonido()); 
        }
    }
    private IEnumerator CambiarNivelDespuesDeSonido()
    {
        GetComponent<Animator>().enabled = true;

        yield return new WaitForSeconds((float)3);

        Audio.SetActive(false);

        Time.timeScale = 0;

        optionPanel.SetActive(true);

      
    }

}
