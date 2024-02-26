using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Elements : MonoBehaviour
{
    [SerializeField] private float cantPoinst;
    [SerializeField] private Score score;

    private void OnCollisionEnter2D(Collision2D collision2D){
        if(collision2D.collider.CompareTag("Player")){
            if (score != null && score.gameObject != null)
            {
                score.AddPoints(cantPoinst);
            } 
            Destroy(gameObject);
            
        }
    }


}
