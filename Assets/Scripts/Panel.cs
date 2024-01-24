using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public int panelId;
    public void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.CompareTag("Player"))
        {
            GameManager.instance.OnPlayerEnterPanel(panelId);
        }
    }

}
