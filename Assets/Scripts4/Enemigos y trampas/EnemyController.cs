using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlink : MonoBehaviour
{
    public float moveSpeed;

    public Transform topPoint, bottomPoint;

    private bool movingUp;

    private Rigidbody2D theRB;

    public SpriteRenderer theSR;
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();

        topPoint.parent = null;
        bottomPoint.parent = null;
    }

    // Update is called once per frame
    void Update()
{
    if (movingUp)
    {
        theRB.velocity = new Vector2(theRB.velocity.x, moveSpeed);


        if (transform.position.y > topPoint.position.y)
        {
            movingUp = false;
        }
    }
    else
    {
        theRB.velocity = new Vector2(theRB.velocity.x, -moveSpeed);


        if (transform.position.y < bottomPoint.position.y)
        {
            movingUp = true;
        }
    }
}
}
