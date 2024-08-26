using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerHealthController : MonoBehaviour
{
    public GameObject Audio;
    public GameObject optionPanel;
    public GameObject gameOver;
    public AudioSource GameOver;
    public static PlayerHealthController instance;
    public int currentHealth, maxHealth;

    public float invincibleLength;
    private float invincibleCounter;

    private SpriteRenderer theSR;
    public Jugador player;
    public PlayerMoveJoystick player2;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;

        theSR = GetComponent<SpriteRenderer>();
           
     }

    void Update()
    {
        if(invincibleCounter > 0)
        {

            invincibleCounter -= Time.deltaTime;

            if(invincibleCounter < 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Lava")
        {
            currentHealth--;
            UIController.instance.UpdateHealthDisplay();
            if(currentHealth > 0)
            {
                player.transform.position = player.lastSafePosition;
                player2.transform.position = player2.lastSafePosition;
            }
            else
            {
                currentHealth = 0;
                StartCoroutine(HandleGameOver());
            }
        }
    }    
    public void DealDamage()
    {
        if(invincibleCounter <=0)
        {
          currentHealth--;

        if(currentHealth <=0)
        {
            currentHealth = 0;
            StartCoroutine(HandleGameOver());
            
        }
        else
        {
            invincibleCounter = invincibleLength;  
            theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);
        }
            UIController.instance.UpdateHealthDisplay();  
        }
        
    }

    public void AumentarVida()
    {
        if(currentHealth < 6)
        {
            currentHealth++;
        }
        UIController.instance.UpdateHealthDisplay();
    }
     private IEnumerator HandleGameOver()
    {
        Audio.SetActive(false);
        gameOver.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        optionPanel.SetActive(true);
    }
}
