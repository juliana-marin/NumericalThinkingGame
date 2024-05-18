using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class JugadorNave : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private float direccionY;
    private float direccionX;
    private Vector2 direccion;
    private int resultadoCorrecto;

    private GeneradorDivisiones generador;

    


    void Start()
    {
      generador = FindObjectOfType<GeneradorDivisiones>();
      
     
    }

    
    void Update()
    {
        direccionY=Input.GetAxisRaw("Vertical");
        direccionX = Input.GetAxisRaw("Horizontal");
       direccion= new Vector2(direccionX, direccionY).normalized; 
    }
    void FixedUpdate(){
       rb.velocity= new Vector2(direccion.x*speed ,direccion.y*speed);
        rb.position= new Vector2(Mathf.Clamp(rb.position.x, -11.0f, 11.0f), Mathf.Clamp(rb.position.y, -4.45f, 4.38f));
    }
       

 
}