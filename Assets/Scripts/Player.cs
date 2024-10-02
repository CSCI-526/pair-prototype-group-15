using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManagerScript gameManager; 
    public int maxHealth = 100; 
    public int currentHealth; 

    public healthBar healthBar;  
    private bool isDead; 
    private float healthDecreaseInterval = 5f; // used for decreasing health with respect to time
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 50 ; 
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        StartCoroutine(DecreaseHealthOverTime());
    }

    // Update is called once per frame
    void Update()
    {
        // Implement Collison detection here and change the health point accordingly
        if(Input.GetKeyDown(KeyCode.Space)){

            TakeDamage(10); // Increasing Health by 10 points when ever player is hit
        }
        if(currentHealth <= 0 && !isDead)
        {
            isDead = true ;
            gameManager.gameOver();
            Debug.Log("Dead");
        }
       
        
    }

    void TakeDamage(int damage){
        currentHealth += damage;

        if (currentHealth> maxHealth)
        {
            currentHealth = maxHealth;   // Visual changes can be added here for when current health exceeds maxhealth
            isDead = true ; 
            gameManager.gameOver();
            Debug.Log("Dead due to excess engergy");
        }
        else 
        {
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health stays within bounds 
        }

        healthBar.SetHealth(currentHealth);
    }

    //Decreasing Health over Time
    IEnumerator DecreaseHealthOverTime()
    {
        while(!isDead)
        {
            yield return new WaitForSeconds(healthDecreaseInterval);
            currentHealth -= 10; // Changes for Damage with time can be done here
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health stays within bounds
            healthBar.SetHealth(currentHealth);
        }
    }

}
