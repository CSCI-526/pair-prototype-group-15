using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpawnRadius = 0.7f;
    public float shootSpeed = 3;
    private float shootTime = 0;
    private float timeCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        shootTime = 1 / shootSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && timeCount > shootTime)
        {            
            float angle = Mathf.Atan2(Input.mousePosition.y - Screen.height / 2, Input.mousePosition.x - Screen.width / 2);
            Vector2 bulletSpawn = new Vector2(transform.position.x, transform.position.y);
            bulletSpawn.x += Mathf.Cos(angle) * bulletSpawnRadius;
            bulletSpawn.y += Mathf.Sin(angle) * bulletSpawnRadius;
            GameObject newBullet = Instantiate(bullet, bulletSpawn, Quaternion.identity);
            newBullet.GetComponent<BulletBehaviour>().setVelocity(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)));
            timeCount = 0;
        }

        // Prevent timeCount from going over 2 * shootTime
        if (timeCount > shootTime * 2)
        {
            timeCount = shootTime * 2;
        }
        else
        {
            timeCount += Time.deltaTime;
        }
    }
}
