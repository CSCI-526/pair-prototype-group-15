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
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth ; 
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            TakeDamage(10);
        }
        if(currentHealth <= 0 && !isDead)
        {
            isDead = true ;
            gameManager.gameOver();
            Debug.Log("Dead");
        }
        
    }

    void TakeDamage(int damage){
        currentHealth -= damage; 
        healthBar.SetHealth(currentHealth);
    }
}
