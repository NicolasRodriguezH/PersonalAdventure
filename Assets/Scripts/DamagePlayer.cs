using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    /* public float timeToRevivePlayer;
    private float timeRevivalCounter;
    private bool playerReviving;
    private GameObject thePlayer; */
    public int damage = 10;

    // Update is called once per frame
    /* void Update()
    {
        if(playerReviving)
        {
            timeRevivalCounter -= Time.deltaTime;
            if(timeRevivalCounter < 0)
            {
                playerReviving = false;
                thePlayer.SetActive(true);
            }
        }
    } */

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            // Colision entre enemigo y jugador
            /* other.gameObject.SetActive(false);
            playerReviving = true;
            timeRevivalCounter = timeToRevivePlayer;
            thePlayer = other.gameObject; */
            other.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
        }    
    }
}
