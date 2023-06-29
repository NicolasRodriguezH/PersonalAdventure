using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void DamageCharacter(int damage)
    {
        currentHealth -= damage;
    }

    // LevelUp para cuando tengamos Game Desing y subamos de nivel el personaje y por tanto aumente la vida
    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        // Recupera toda la vida al subir de nivel!
        currentHealth = maxHealth;
    }
}
