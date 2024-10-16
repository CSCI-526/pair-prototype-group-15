using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{   public Transform player; //to transform
    public float sizeIncreaseAmount = 0.2f; // Amount to increase player's size
    private float colaHitTime = -1f; // Time when Cola bullet hits the player
    private float mentosHitTime = -1f; // Time when Mentos bullet hits the player
    public float collisionTimeWindow = 2f; // Time window in seconds (2 seconds)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detect if the "ColaBullet" hits the player
        if (collision.gameObject.name == "cola")
        {
            colaHitTime = Time.time; // Record time of Cola bullet hit
        }

        // Detect if the "MentosBullet" hits the player
        if (collision.gameObject.name == "mentos")
        {
            mentosHitTime = Time.time; // Record time of Mentos bullet hit
        }

        // Check if both Cola and Mentos bullets hit within the time window
        if (colaHitTime > 0 && mentosHitTime > 0 && Mathf.Abs(colaHitTime - mentosHitTime) <= collisionTimeWindow)
        {
            IncreasePlayerSize(); // Increase player's size
            colaHitTime = -1f; // Reset the timers
            mentosHitTime = -1f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IncreasePlayerSize()
    {
        player.localScale += new Vector3(sizeIncreaseAmount, sizeIncreaseAmount, 0); // Increase player size
        Debug.Log("Player size increased!");
    }
}



