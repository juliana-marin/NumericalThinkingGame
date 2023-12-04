using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    private Rigidbody2D rigidbody2D;
    [Header("Movement")]
    private float horizontalMovement = 0f;
    [SerializeField] private float speedMovement;
    [Range(0,0.3f)][SerializeField] private float motionSmoothing;
    private Vector3 speed = Vector3.zero;
    private bool lookingRight = true;

    [Header("Jump")]
    [SerializeField] private float strengthJump;
    [SerializeField] private LayerMask checkGroud;
    [SerializeField] private Transform groundController;
    [SerializeField] private Vector3 dimension;
    [SerializeField] private bool isGround;
    private bool betterJump = false;

    [Header("Animation")]
    private Animator animator;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal")* speedMovement;
        animator.SetFloat("Horizontal", Mathf.Abs(horizontalMovement));
        if(Input.GetButtonDown("Jump")){
            betterJump = true;
        }
    }

      private void FixedUpdate()
    {
        isGround = Physics2D.OverlapBox(groundController.position, dimension, 0f, checkGroud);
        animator.SetBool("isGround", isGround);

        Mover(horizontalMovement * Time.fixedDeltaTime, betterJump);

        betterJump = false;
    }

    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rigidbody2D.velocity.y);
        rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, velocidadObjetivo, ref speed, motionSmoothing);

        if (mover > 0 && !lookingRight)
        {
            Girar();
        }
        else if (mover < 0 && lookingRight)
        {
            Girar();
        }

        if (isGround && saltar)
        {
            isGround = false;
            rigidbody2D.AddForce(new Vector2(0f, strengthJump));
        }
    }

    private void Girar()
    {
        lookingRight = !lookingRight;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundController.position, dimension);
    }
}
