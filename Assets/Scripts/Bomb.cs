using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public GameObject impactEffect;
    public float radius = 5;
    public int damageAmount = 100;
    public int health = 20;
    Collision collision;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if(health <= 0)
        {
            //FindObjectOfType<AudioManager>().Play("Explosion");
            GameObject impact = Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(impact, 2);
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider nearbyObject in colliders)
            {
                if (nearbyObject.tag == "Enemy")
                {
                    FindObjectOfType<Enemy>().TakeDamage(damageAmount);
                }
            }
            this.enabled = false;
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
    }

    
}
