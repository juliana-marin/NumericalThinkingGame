using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFuego : MonoBehaviour
{
    public bool activar;
    private Animator [] animadoresHijos;
    private CircleCollider2D[] collidersHijos;
    void Start()
    {
        animadoresHijos = GetComponentsInChildren<Animator>();
        collidersHijos = GetComponentsInChildren<CircleCollider2D>();     
    }
    void Update()
    {
        if(activar == false)
        {
        foreach (Animator animatorHijo in animadoresHijos)
        {
            animatorHijo.SetBool("Activar", activar);
        }
        foreach (CircleCollider2D colliderHijo in collidersHijos)
        {
            colliderHijo.enabled = activar;
        }
        }
    }
}

