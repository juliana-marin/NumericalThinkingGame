using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

[System.Serializable]
public struct Fraccion
{
    public int numerador;
    public int denominador;
}
public class Contenedor : MonoBehaviour
{
    public GameObject nivelCompletado;
    public GameObject gameOver;
    public GameObject[] barrasPrefabs;
    public Fraccion[] fracciones; 
    public TextMeshProUGUI fraccionText;
    private Fraccion fraccionInicial;

    public float tiempoEntreGeneraciones = 8f;
    void Start()
    {
        StartCoroutine(ReproducirInstrucciones());
        GenerarFraccionAleatoria();

    }
    public Fraccion GenerarFraccionAleatoria()
    {
        DesactivarBarrasEnEscena();
        int numerador = UnityEngine.Random.Range(1, 11);
        int denominador = UnityEngine.Random.Range(numerador, 11);
        fraccionInicial = new Fraccion { numerador = numerador, denominador = denominador };
        Debug.Log("Fracción inicial GenerarFraccionAleatoria: " + fraccionInicial.numerador + "/" + fraccionInicial.denominador);
        fraccionText.text = $"{fraccionInicial.numerador}/{fraccionInicial.denominador}";
        InstantiateBarra(fraccionInicial);
        return fraccionInicial;

    }
    public Fraccion ObtenerFraccionInicial()
    {
        return fraccionInicial;
    }
    private void DesactivarBarrasEnEscena()
    {
        GameObject[] barrasEnEscena = GameObject.FindGameObjectsWithTag("Fraccion");

        foreach (GameObject barra in barrasEnEscena)
        {
            Destroy(barra);
        }
    }
    void InstantiateBarra(Fraccion fraccion)
    {
        GameObject prefabFraccion = ObtenerPrefabFraccion(fraccion);
        if (prefabFraccion != null)
        {
            GameObject nuevaBarraGameObject = Instantiate(prefabFraccion, transform);
            nuevaBarraGameObject.transform.position = new Vector3(UnityEngine.Random.Range(6f, 7f), UnityEngine.Random.Range(-1f, 1f), -1f);
            Rigidbody2D rbs = nuevaBarraGameObject.GetComponent<Rigidbody2D>();
            if (rbs == null)
            {
                rbs = nuevaBarraGameObject.AddComponent<Rigidbody2D>();
            }
            rbs.velocity = new Vector2(-1f, 0f);
        }
        int indicePrefab = UnityEngine.Random.Range(0, barrasPrefabs.Length);
        GameObject barraGameObject = Instantiate(barrasPrefabs[indicePrefab], transform);
        barraGameObject.transform.position = new Vector3(UnityEngine.Random.Range(6f, 7f), UnityEngine.Random.Range(-1f, 1f), -1f); 
        Rigidbody2D rb = barraGameObject.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = barraGameObject.AddComponent<Rigidbody2D>();
        }
        rb.velocity = new Vector2(-1f, 0f); 
    }
    GameObject ObtenerPrefabFraccion(Fraccion fraccion)
    {
        for (int i = 0; i < fracciones.Length; i++)
        {
            if (fracciones[i].numerador == fraccion.numerador && fracciones[i].denominador == fraccion.denominador)
            {
                if (i < barrasPrefabs.Length)
                {
                    return barrasPrefabs[i];
                }
                else
                {
                    Debug.LogError("El índice está fuera del rango de barrasPrefabs.");
                    return null;
                }
            }
        }
        Debug.LogError("No se encontró un prefab para la fracción especificada.");
        return null;
    }
    IEnumerator ReproducirInstrucciones()
    {

        Time.timeScale = 0f;
        AudioSource audioSource = GameObject.Find("Instrucciones").GetComponent<AudioSource>();
        audioSource.Play();
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        Time.timeScale = 1f;
    }
}













