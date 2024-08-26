using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCont : MonoBehaviour
{
    public static UI instance;
    public AudioClip sonidoObjeto;


    private void OnCollisionEnter2D(Collision2D collision2D){
        if(collision2D.collider.CompareTag("Player")){
            if(UI.instance.getOperacion() == "Sustraccion")
            {
                UI.instance.SetContadorSustracction();
            }else{
                UI.instance.SetContador();
            }
            if(sonidoObjeto != null){
                AudioSource.PlayClipAtPoint(sonidoObjeto, transform.position, 2.0f);
            }
            Destroy(gameObject);
            
        }
    }

}