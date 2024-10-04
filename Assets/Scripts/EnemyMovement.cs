using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject bullet;
    public Transform player;    
    public float radius = 10f;   
    public float topSpeedOut = 5f;
    public float topSpeedIn = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        float currentSpeed;
        currentSpeed = CalculateSpeed(distance);

        Vector3 direction;
        if (distance > radius)
        {
            direction = (player.position - transform.position).normalized;
        }
        else
        {
            direction = (transform.position - player.position).normalized;
        }

        rb.velocity = direction * currentSpeed;
    }

    private float CalculateSpeed(float distance)
    {
        if (distance < radius)
        {
            return topSpeedIn * (1 - (distance / radius));
        }
        else
        {
            return topSpeedOut * (distance / radius);
        }
    }
}
