using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private GameObject damageEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
            GameObject ps = Instantiate(damageEffect, transform.position, transform.rotation);
            Destroy(ps, 2f);
            

            
        }
    }
}
