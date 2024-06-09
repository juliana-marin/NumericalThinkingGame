using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    public GameObject DustLeft;
    public GameObject DustRight;
    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    public FixedJoystick joystick;
    public AudioSource clip;
    public bool colision = false;
    [Header ("Salto")]
    private bool canDoubleJump;
    public float fuerzaSalto;
    public float doubleJumpSpeed = 2.5f;
    [Header ("Movimiento")]
    public float runSpeedHorizontal = 2;

    public float moveSpeed;
    [Header ("Grounded")]
    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask WhatIsGround;
    [Header ("Animaciones")]
    private Animator animator;
    private SpriteRenderer theSR;
    public Rigidbody2D theRB;   
    bool isTouchingFront = false;
    bool wallSliding;
    public float wallSlidingSpeed = 0.75f;
    bool isTouchingDerecha;
    bool isTouchingIzquierda;
    public Vector3 lastSafePosition;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator> ();
        theRB = GetComponent<Rigidbody2D>();
        theSR = GetComponent<SpriteRenderer>();
     }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = joystick.Horizontal + runSpeedHorizontal;

        //transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * moveSpeed;

        //animator.SetFloat("moveSpeed",Mathf.Abs(theRB.velocity.x));

        theRB.velocity = new Vector2(moveSpeed * horizontalMove, theRB.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, WhatIsGround);

        if(theRB.velocity.x > 0)
        {
            theSR.flipX = false;
            //animator.SetBool("Run", true);
            if(isGrounded == true)
            {
                DustLeft.SetActive(true);
                DustRight.SetActive(false);
            }
        }

        else if (theRB.velocity.x < 0)
        {
            theSR.flipX = true;
            //animator.SetBool("Run", true);
            if(isGrounded == true)
            {
                DustLeft.SetActive(false);
                DustRight.SetActive(true);
            }
        }

        else
       {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
            animator.SetBool("Run", false);
            DustLeft.SetActive(false);
            DustRight.SetActive(false);
        }

       animator.SetFloat("moveSpeed",Mathf.Abs(theRB.velocity.x));
       animator.SetBool("isGrounded", isGrounded);
        
        animator.SetBool("isGrounded", isGrounded);

        if(isGrounded == false)
        {
            animator.SetBool("estaSaltando", true);
            animator.SetBool("Run", false);
            DustLeft.SetActive(false);
            DustRight.SetActive(false);
        }
        if(isGrounded == true)
        {
            animator.SetBool("estaSaltando", false);
            animator.SetBool("DoubleJump", false); 
            animator.SetBool("Falling", false); 
            lastSafePosition = transform.position;

        }

        if(theRB.velocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        else if (theRB.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }
           

       if  (isTouchingFront == true && isGrounded == false)
       {
            wallSliding = true;
       }
       else
       {
        wallSliding = false;
       }

       if (wallSliding)
       {
        animator.Play("Wall");
        theRB.velocity = new Vector2(theRB.velocity.x, Math.Clamp(theRB.velocity.y,-wallSlidingSpeed,float.MaxValue));
        
       }

      
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ParedDerecha"))
        {
            isTouchingFront = true;
            isTouchingDerecha = true;
        }

        if (collision.gameObject.CompareTag("ParedIzquierda"))
        {
            isTouchingFront = true;
            isTouchingIzquierda = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
            isTouchingFront = false;
            isTouchingDerecha = false;
            isTouchingIzquierda = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.transform.CompareTag("A"))
         {
            colision = true;
            //generador.respuestaUsuario = respuestaA.respuestaa;
         }
         if (collision.transform.CompareTag("B"))
         {
            colision = true;
            //generador.respuestaUsuario = respuestaB.respuestab;
         }
         if (collision.transform.CompareTag("C"))
         {
            colision = true;
            //generador.respuestaUsuario = respuestaC.respuestac;
         }
         
    }

    public void Jump()
    {
        if (isGrounded)
        {
            clip.Play();
            canDoubleJump = true;
            theRB.velocity = new Vector2(theRB.velocity.x, fuerzaSalto);
        }
        else
        {
            if (canDoubleJump)
            {
                animator.SetBool("DoubleJump", true);
                theRB.velocity = new Vector2(theRB.velocity.x, fuerzaSalto);
                canDoubleJump = false;
            }

        }
    }
}
