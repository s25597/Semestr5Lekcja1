using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    public int damage = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Stats stats = collision.gameObject.GetComponent<Stats>();
            //stats.health -= damage;
            stats.DecreaseHealth(damage);
        }
    }

}
