using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2;
    public float lifeTime = 2;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
       transform.Translate(Vector2.down*speed*Time.deltaTime);
    }
}
