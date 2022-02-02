using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunOld : MonoBehaviour
{/*
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 8f;
    public float impactForce = 500f;
    public float reloadTime = 0.5f;
    public int amountOfBullets = 10;
    public bool isAutomatic = false;
    public string attackSound;
    public string reloadSound;
    public string shootNoAmmoSound;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public TMP_Text bulletCounter;

    private PauseScreen pauseScreenScript;
    private PlayerMovement playerMovementScript;


    public Ammobar ammobarScript;

    private AudioManager audioManagerScript;

    private float nextTimeToFire = 0f;
    private int currentBullets = 0;

    private int layerMask = 1 << 10;

    private void Start()
    {
        currentBullets = amountOfBullets;
        bulletCounter.text = currentBullets.ToString();
        layerMask = ~layerMask;
        audioManagerScript = FindObjectOfType<AudioManager>();
        ammobarScript.SetMaxAmmo(amountOfBullets);
        pauseScreenScript = GameObject.FindObjectOfType<PauseScreen>();
        playerMovementScript = GameObject.FindObjectOfType<PlayerMovement>();


    }

    private void OnEnable()
    {
        ammobarScript.SetMaxAmmo(amountOfBullets);
        ammobarScript.SetAmmo(currentBullets);
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            ammobarScript.SetMaxAmmo(amountOfBullets);
        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            ammobarScript.SetMaxAmmo(amountOfBullets);
        }

        if (currentBullets > 0)
        {
            if (isAutomatic == true)
            {
                if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire && pauseScreenScript.isPaused == false && playerMovementScript.isDead == false)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    Shoot();
                }
            }
            else
            {
                if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && pauseScreenScript.isPaused == false && playerMovementScript.isDead == false)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    Shoot();
                }
            }
        }
        else
        {
            if (isAutomatic == true)
            {
                if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && pauseScreenScript.isPaused == false && playerMovementScript.isDead == false)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    audioManagerScript.Play(shootNoAmmoSound);
                }
            }
            else
            {
                if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && pauseScreenScript.isPaused == false && playerMovementScript.isDead == false)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    audioManagerScript.Play(shootNoAmmoSound);
                }
            }
        }

        if(Input.GetButton("Reload") && currentBullets < amountOfBullets)
        {
            currentBullets = amountOfBullets;
            nextTimeToFire = Time.time + 1f / reloadTime;
            bulletCounter.text = "Ladataan...";
            audioManagerScript.Play(reloadSound);
            
        }

        if(Time.time >= nextTimeToFire)
        {
            bulletCounter.text = currentBullets.ToString();
            bulletCounter.text = currentBullets.ToString();
            ammobarScript.SetAmmo(currentBullets);
            
        }
    }

    private void Shoot()
    {
        muzzleFlash.Play();
        currentBullets--;
        bulletCounter.text = currentBullets.ToString();
        audioManagerScript.Play(attackSound);

        ammobarScript.SetAmmo(currentBullets);

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, layerMask))
        {

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }*/
}
