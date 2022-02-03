using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    Transform player;
    private float shootingDelay = 0f;

    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public float shootingSpeed = 1f;

    private AudioManager audioManagerScript;

    private void Start()
    {
        player = GetComponent<Transform>();

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if (Time.time >= shootingDelay)
            {
                Shoot();
                shootingDelay = Time.time + 1f / shootingSpeed;
            }
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, player.position, player.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(player.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
