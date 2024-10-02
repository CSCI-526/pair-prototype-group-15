using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject bullet;
    public Transform player;    
    public float radius = 10f;   
    public float topSpeedOut = 5f;
    public float topSpeedIn = 10f;
    public float shootSpeed = 3f;
    public float bulletSpawnRadius = 0.7f;

    private Rigidbody2D rb;
    private float shootTime;
    private float timeCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shootTime = 1 / shootSpeed;
    }

    void Update()
    {
        move();
        fire();
    }

    private void move()
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

    private void fire()
    {
        if(timeCount > shootTime)
        {
            float angle = Mathf.Atan2(player.position.y - transform.position.y, player.position.x - transform.position.x);
            Vector2 bulletSpawn = new Vector2(transform.position.x, transform.position.y);
            bulletSpawn.x += Mathf.Cos(angle) * bulletSpawnRadius;
            bulletSpawn.y += Mathf.Sin(angle) * bulletSpawnRadius;
            GameObject newBullet = Instantiate(bullet, bulletSpawn, Quaternion.identity);
            newBullet.GetComponent<BulletBehaviour>().setVelocity(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)));
            timeCount = 0;
        }

        if(timeCount > shootTime * 2)
        {
            timeCount = 0;
        }
        else
        {
            timeCount += Time.deltaTime;
        }
    }
}
