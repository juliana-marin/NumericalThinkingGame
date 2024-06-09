using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFuego : MonoBehaviour
{
    public bool activar;
    private Animator [] animadoresHijos;
    private CircleCollider2D[] collidersHijos;

    // Start is called before the first frame update
    void Start()
    {
        // Obtener todos los componentes de Animator de los hijos
        animadoresHijos = GetComponentsInChildren<Animator>();
        // Obtener todos los componentes de BoxCollider2D de los hijos
        collidersHijos = GetComponentsInChildren<CircleCollider2D>();     
    }
    void Update()
    {
        if(activar == false)
        {
        // Iterar sobre los animadores de los hijos y establecer la animación según el estado de activar
        foreach (Animator animatorHijo in animadoresHijos)
        {
            animatorHijo.SetBool("Activar", activar);
        }
        // Iterar sobre los colliders de los hijos y desactivarlos según el estado de activar
        foreach (CircleCollider2D colliderHijo in collidersHijos)
        {
            colliderHijo.enabled = activar;
        }
        }
    }
}

