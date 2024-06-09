using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCont : MonoBehaviour
{
    public static UI instance;

    private void OnCollisionEnter2D(Collision2D collision2D){
        if(collision2D.collider.CompareTag("Player")){
            if(UI.instance.getOperacion() == "Sustracción")
            {
                UI.instance.SetContadorSustracction();
            }else{
                UI.instance.SetContador();
            }
            Destroy(gameObject);
            
        }
    }

}