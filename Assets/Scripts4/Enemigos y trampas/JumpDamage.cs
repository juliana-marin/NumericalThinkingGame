using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDamage : MonoBehaviour
{
    public ScoreManager puntaje;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.transform.parent.gameObject.SetActive(false);
            Destroy(other.transform.parent.gameObject);
            puntaje.EnemyDefeated();
           
        }
    }

}
