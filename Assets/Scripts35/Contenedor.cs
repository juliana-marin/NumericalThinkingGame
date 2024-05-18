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

    public GameObject[] barrasPrefabs;
   
    public Fraccion[] fracciones; // Array de fracciones que se asignarán a las barras
    public TextMeshProUGUI fraccionText;
    private Fraccion fraccionInicial;
    // private Fraccion fraccionPrincipal; 
    public float tiempoEntreGeneraciones = 8f;
    




   //public VidaController vidaController;
   


    
    void Start()
    {
             StartCoroutine(ReproducirInstrucciones());
            GenerarFraccionAleatoria();

    }




//public static Fraccion fraccionInicial { get; private set; }
    public Fraccion GenerarFraccionAleatoria()
    {
        // Desactivar las barras existentes en la escena
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
       

        //--------------------------Fraccion de barra ( imagen) equivalente---------
        GameObject prefabFraccion = ObtenerPrefabFraccion(fraccion);// se encarga de mostrar o crear la fraccion equivalente correcta
          if (prefabFraccion != null)
        {
            // Generar nombre único para la primera barra
        
           GameObject nuevaBarraGameObject = Instantiate(prefabFraccion, transform);
       
//            nuevaBarraGameObject.transform.position = new Vector3(nuevaBarraGameObject.transform.position.x, nuevaBarraGameObject.transform.position.y, -1f);
  nuevaBarraGameObject.transform.position = new Vector3(UnityEngine.Random.Range(6f,7f), UnityEngine.Random.Range(-1f, 1f), -1f); // Cambia 5f por la posición X deseada





        // Agregar componente Rigidbody2D si no está presente
        Rigidbody2D rbs = nuevaBarraGameObject.GetComponent<Rigidbody2D>();
        if (rbs == null)
        {
            rbs = nuevaBarraGameObject.AddComponent<Rigidbody2D>();
        }

        // Establecer velocidad de la barra en el eje X (de derecha a izquierda)
        rbs.velocity = new Vector2(-1f, 0f);
        } 

        
//------------------ Fraccion de barra (imagen)barra aleatoria-------------------------
         int indicePrefab = UnityEngine.Random.Range(0, barrasPrefabs.Length);
    GameObject barraGameObject = Instantiate(barrasPrefabs[indicePrefab], transform);

    // Ajustar la posición Z para que la barra esté delante del fondo
//    barraGameObject.transform.position = new Vector3(barraGameObject.transform.position.x, barraGameObject.transform.position.y, -1f);
    barraGameObject.transform.position = new Vector3(UnityEngine.Random.Range(6f,7f), UnityEngine.Random.Range(-1f, 1f), -1f); // Cambia 5f por la posición X deseada

//  float   randomY = UnityEngine.Random.Range(-4.25f, 4.25f);
//            GameObject barraGameObject = Instantiate(prefabFraccion, new Vector3(9.9f, randomY, 0f), Quaternion.identity);
                     
        // Agregar componente Rigidbody2D si no está presente
    Rigidbody2D rb = barraGameObject.GetComponent<Rigidbody2D>();
    if (rb == null)
    {
        rb = barraGameObject.AddComponent<Rigidbody2D>();
    }

    // Establecer velocidad de la barra en el eje X (de derecha a izquierda)
    rb.velocity = new Vector2(-1f, 0f); // Cambio de 2f a -2f para invertir la dirección
 // Mensaje de depuración para imprimir la velocidad aplicada
//    Debug.Log("Velocidad aplicada a la barra: " + rb.velocity);
//    Debug.Log("Barra GameObject: " + barraGameObject.name); // Agrega este mensaje de depuración


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
    // Pausar el juego
    Time.timeScale = 0f;

    AudioSource audioSource = GameObject.Find("Instrucciones").GetComponent<AudioSource>();

    // Reproducir el audio de las instrucciones
    audioSource.Play();

    // Esperar a que termine la reproducción del audio
    while (audioSource.isPlaying)
    {
        yield return null;
    }

    // Reanudar el juego
    Time.timeScale = 1f;
}




}













