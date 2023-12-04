using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] private float cantPoinst;
    [SerializeField] private Score score;
    private void OnCollisionEnter2D(Collision2D other){
        if(other.collider.CompareTag("Player")){
            score.AddPoints(cantPoinst);
            Destroy(gameObject);
        }

    }
}
