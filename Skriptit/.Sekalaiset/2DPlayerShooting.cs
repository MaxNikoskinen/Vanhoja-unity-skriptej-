using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    Transform player;
    private float shootingDelay = 0f;

    public GameObject bulletPrefab;
    public GameObject bulletShiftPrefab;
    public float bulletSpeed = 20f;
    public float shootingSpeed = 1f;

    private AudioManager audioManagerScript;

    private GameObject bulletUsingPrefab;

    private void Start()
    {
        player = GetComponent<Transform>();
        audioManagerScript = FindObjectOfType<AudioManager>();
        bulletUsingPrefab = bulletPrefab;
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

        // Hidastus luodit
        if (Input.GetKey(KeyCode.LeftShift))
        {
            bulletUsingPrefab = bulletShiftPrefab;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            bulletUsingPrefab = bulletPrefab;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletUsingPrefab, player.position, player.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(player.up * bulletSpeed, ForceMode2D.Impulse);
        audioManagerScript.Play("Shoot");
    }
}
