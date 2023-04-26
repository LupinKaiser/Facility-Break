using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;


public class Gun : MonoBehaviour
{
    public Transform fpsCam;
    public float range = 20;
    public float impactForce = 150;
    public int damageAmount = 20;

    public int fireRate = 10;
    private float nextTimeToFire = 0;

    public GameObject impactEffect;
   


    InputAction shoot;

    void Start()
    {
        shoot = new InputAction("Shoot", binding: "<mouse>/leftButton");
        shoot.AddBinding("<Gamepad>/x");

        shoot.Enable();

     
    }
    
    // Update is called once per frame
    void Update()
    {
        

        bool isShooting = shoot.ReadValue<float>() == 1;

        if (isShooting && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Fire();
        }

    }

    private void Fire()
    {
        FindObjectOfType<AudioManager>().Play("Shoot");

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.position + fpsCam.forward, fpsCam.forward, out hit, range))
        {
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            Enemy e = hit.transform.GetComponent<Enemy>();
            if(e != null)
            {
                e.TakeDamage(damageAmount);
                return;
            }

            Bomb i = hit.transform.GetComponent<Bomb>();
            if (i != null)
            {
                i.TakeDamage(damageAmount);
                return;
            }

            Boss b = hit.transform.GetComponent<Boss>();
            if (b != null)
            {
                b.TakeDamage(damageAmount);
                return;
            }

            Quaternion impactRotation = Quaternion.LookRotation(hit.normal);
            GameObject impact = Instantiate(impactEffect, hit.point, impactRotation);
            impact.transform.parent = hit.transform;
            Destroy(impact, 5);
        }
    }

    
}
