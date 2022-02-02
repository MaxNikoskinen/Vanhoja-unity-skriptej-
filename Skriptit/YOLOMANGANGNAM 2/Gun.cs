using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;
    public float reloadTime = 0.5f;
    public int amountOfBullets = 10;
    public bool automatic = false;
    public bool useAmmo = true;
    public string attackSound;
    public string reloadSound;
    public string shootNoAmmoSound;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public ParticleSystem bullet;
    public GameObject impactEffect;
    public TMP_Text ammoCounter;
    public GameObject ammoUIElement;
    public Ammobar ammobarScript;
    public GameObject reloadIndicator;

    private AudioManager audioManagerScript;
    private PauseScreen pauseScreenScript;
    private HealthSystem healthSystemScript;

    private float nextTimeToFire = 0f;
    private float nextTimeToFireReload = 0f;
    private int currentBullets = 0;
    private bool reloading = false;

    private void Start()
    {
        currentBullets = amountOfBullets;
        audioManagerScript = FindObjectOfType<AudioManager>();
        pauseScreenScript = FindObjectOfType<PauseScreen>();
        healthSystemScript = FindObjectOfType<HealthSystem>();


        if (useAmmo == true)
        {
            ammoUIElement.SetActive(true);
            ammobarScript.maximum = amountOfBullets;
            ammobarScript.current = currentBullets;
            ammoCounter.text = currentBullets.ToString() + " / " + amountOfBullets.ToString();
        }
        else if (useAmmo == false)
        {
            ammoUIElement.SetActive(false);
        }
    }

    private void OnEnable()
    {
        if (useAmmo == true)
        {
            ammoUIElement.SetActive(true);
            ammobarScript.maximum = amountOfBullets;
            ammobarScript.current = currentBullets;
            ammoCounter.text = currentBullets.ToString() + " / " + amountOfBullets.ToString();
        }
        else if (useAmmo == false)
        {
            ammoUIElement.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (reloadIndicator != null)
        {
            reloadIndicator.SetActive(false);
        }

        if (reloading == true)
        {
            reloading = false;
            nextTimeToFire = 0f;
            if(reloadSound != null)
            {
                audioManagerScript.StopPlaying(reloadSound);
            }
        }
    }

    private void Update()
    {
        //Ammu
        if (currentBullets > 0 && pauseScreenScript.isPaused == false && healthSystemScript.isDead == false)
        {
            if (automatic == false)
            {
                if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    Shoot();
                }
            }

            else if (automatic == true)
            {
                if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    Shoot();
                }
            }
        }
        else if(currentBullets <= 0 && pauseScreenScript.isPaused == false && healthSystemScript.isDead == false)
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
            {
                audioManagerScript.Play(shootNoAmmoSound);
            }
        }

        //Lataa ase
        if (Input.GetKeyDown(KeyCode.R) && currentBullets < amountOfBullets && reloading == false && useAmmo == true && healthSystemScript.isDead == false && pauseScreenScript.isPaused == false)
        {
            audioManagerScript.StopPlaying(reloadSound);
            nextTimeToFire = Time.time + 1f / reloadTime;
            audioManagerScript.Play(reloadSound);
            reloading = true;
            nextTimeToFireReload = Time.time + 1f / reloadTime;
            reloadIndicator.SetActive(true);
        }

        //Laita ammuksen aseen lippaaseen ampumisen latauksen jälkeen
        if (Time.time >= nextTimeToFireReload && reloading == true)
        {
            currentBullets = amountOfBullets;
            ammobarScript.maximum = amountOfBullets;
            ammobarScript.current = currentBullets;
            ammoCounter.text = currentBullets.ToString() + " / " + amountOfBullets.ToString();
            reloading = false;
            reloadIndicator.SetActive(false);
        }
        
        //Pysäytä lataus ääni kun peli pysäytetään
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Kun pysäytetty
            if (pauseScreenScript.isPaused == true)
            {
                audioManagerScript.Pause(reloadSound);
            }

            //Kun ei
            else
            {
                if (reloading)
                {
                    audioManagerScript.Play(reloadSound);
                }
            }
        }
    }

    private void Shoot()
    {
        muzzleFlash.Play();
        bullet.Clear();
        bullet.Play();

        audioManagerScript.Play(attackSound);

        if (useAmmo == true)
        {
            currentBullets--;
            ammobarScript.maximum = amountOfBullets;
            ammobarScript.current = currentBullets;
            ammoCounter.text = currentBullets.ToString() + " / " + amountOfBullets.ToString();
        }
        

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if(enemy != null)
            {
                enemy.TakeDamage(damage);
                audioManagerScript.Play("Hitmarker");
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
        
    }
}
