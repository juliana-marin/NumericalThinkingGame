using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public AudioSource clip;
    void Start()
    {

    }
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthController.instance.DealDamage();
            clip.Play();
        }

    }
}
