using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHP = 100;
    public GameObject projectile;
    public Transform projectilePoint;
    
    public Animator animator;

    public Door door;

    public void Shoot()
    {
       
        Rigidbody rb = Instantiate(projectile, projectilePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 30f, ForceMode.Impulse);
        rb.AddForce(transform.up * 7f, ForceMode.Impulse);
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        if(enemyHP <= 0)
        {
            animator.SetTrigger("death");
            GetComponent<CapsuleCollider>().enabled = false;
            door.IncreasesDeath();
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }
}
