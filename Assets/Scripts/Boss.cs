using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public int enemyHP = 250;
    public GameObject projectile;
    public Transform projectilePoint;

    public Animator animator;

    

    public void Shoot()
    {

        Rigidbody rb = Instantiate(projectile, projectilePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 30f, ForceMode.Impulse);
        rb.AddForce(transform.up * 3f, ForceMode.Impulse);
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        if (enemyHP <= 0)
        {
            SceneManager.LoadScene("Win");
            
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }
}
