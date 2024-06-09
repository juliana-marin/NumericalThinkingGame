using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;


public class BulletPlantRight : MonoBehaviour
{
    public float speed = 2;
    public float lifeTime = 2;
    public bool right;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        if(right)
        {
            transform.Translate(Vector2.right*speed*Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left*speed*Time.deltaTime);    
        }
    }
}