using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public static int playerHP = 100;
    public TextMeshProUGUI playerHPText;
   

    
    void Start()
    {
        playerHP = 200;
    }

    // Update is called once per frame
    void Update()
    {
        playerHPText.text = "+" + playerHP;
        if (playerHP <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    public IEnumerator TakeDamage(int damageAmount)
    {     
        playerHP -= damageAmount;
     
        yield return new WaitForSeconds(1);
       
    }
}
