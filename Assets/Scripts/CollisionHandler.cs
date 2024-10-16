using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private HealthController healthController ;

    void Awake()
    {
        healthController = GetComponent<HealthController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the object collides with an enemy or player, apply damage accordingly
        if (collision.gameObject.tag == "Enemy" && healthController.isPlayer)
        {
            // Call the TakeDamage method in HealthController and pass the bullet's calories (damage)
            float damage = collision.gameObject.GetComponent<BulletBehaviour>().calories;
            healthController.TakeDamage(damage);
        }
        else if (collision.gameObject.tag == "Player" && !healthController.isPlayer)
        {
            // Call the TakeDamage method in HealthController and pass the bullet's calories (damage)
            float damage = collision.gameObject.GetComponent<BulletBehaviour>().calories;
            healthController.TakeDamage(damage);
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
}
