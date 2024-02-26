using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MoveEnemy : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float speedMovement;
    public LayerMask layerDown;
    public LayerMask layerFront;
    public float distanceDown;
    public float distanceFront;
    public Transform controllerDown;
    public Transform controllerFront;
    public bool informationDown;
    public bool informationFront;
    private bool lookRight = true;

    private void Update()
    {
        rigidbody2D.velocity = new Vector2(speedMovement,rigidbody2D.velocity.y);
        informationFront = Physics2D.Raycast(controllerFront.position, transform.right, distanceFront, layerFront);
        informationDown = Physics2D.Raycast(controllerDown.position, transform.up * -1, distanceDown, layerDown);

        
        if(informationFront || !informationDown){
            Girar();
        }
    }

    private void Girar()
    {
        lookRight = !lookRight;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        speedMovement *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controllerFront.transform.position, controllerFront.transform.position +transform.right * distanceFront);
        Gizmos.DrawLine(controllerDown.transform.position, controllerDown.transform.position + transform.up * -1 * distanceDown);

    }

    private void OnCollisionEnter2D(Collision2D collision2D){
        if(collision2D.collider.CompareTag("Player")){
            MovimientoCamara.Instance.MoverCamara(2,2, 0.2f);
            
        }
    }


}

