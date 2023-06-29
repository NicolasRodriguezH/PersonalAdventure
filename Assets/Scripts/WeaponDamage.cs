using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag.Equals("Enemy"))
        {
            other.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
            //Destroy(other.gameObject);
        }    
    }
}
