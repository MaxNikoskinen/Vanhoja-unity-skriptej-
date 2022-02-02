using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeoponSwithing : MonoBehaviour
{
    private PauseScreen pauseScreenScript;

    private int selectedWeapon = 0;

    public GameObject ammoUIElement;

    public GameObject selected1;
    public GameObject selected2;
    public GameObject selected3;
    public GameObject selected4;
    public GameObject selected5;

    private string switchSound = "Weapon Switch";

    private AudioManager audioManagerScript;

    private void Start()
    {
        audioManagerScript = GameObject.FindObjectOfType<AudioManager>();
        pauseScreenScript = GameObject.FindObjectOfType<PauseScreen>();
        SelectWeapon();
    }

    private void Update()
    {
        //UI
        if(selectedWeapon == 0) //1
        {
            selected1.SetActive(true);
            selected2.SetActive(false);
            selected3.SetActive(false);
            selected4.SetActive(false);
            selected5.SetActive(false);
        }
        else if(selectedWeapon == 1) //2
        {
            selected1.SetActive(false);
            selected2.SetActive(true);
            selected3.SetActive(false);
            selected4.SetActive(false);
            selected5.SetActive(false);
        }
        else if (selectedWeapon == 2) //3
        {
            selected1.SetActive(false);
            selected2.SetActive(false);
            selected3.SetActive(true);
            selected4.SetActive(false);
            selected5.SetActive(false);
        }
        else if (selectedWeapon == 3) //4
        {
            selected1.SetActive(false);
            selected2.SetActive(false);
            selected3.SetActive(false);
            selected4.SetActive(true);
            selected5.SetActive(false);
        }
        else if (selectedWeapon == 4) //5
        {
            selected1.SetActive(false);
            selected2.SetActive(false);
            selected3.SetActive(false);
            selected4.SetActive(false);
            selected5.SetActive(true);
        }


        //Näppäimet
        if (pauseScreenScript.isPaused == false)
        {
            int previousSelectedWeapon = selectedWeapon;

            if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
            {
                if (selectedWeapon >= transform.childCount - 1)
                    return;
                else
                    selectedWeapon++;
            }

            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
            {
                if (selectedWeapon <= 0)
                    return;
                else
                    selectedWeapon--;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) && transform.childCount >= 2)
            {
                selectedWeapon = 0;
                ammoUIElement.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
            {
                selectedWeapon = 1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
            {
                selectedWeapon = 1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 2)
            {
                selectedWeapon = 2;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 2)
            {
                selectedWeapon = 3;
            }
            if (Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >= 2)
            {
                selectedWeapon = 4;
            }

            if (previousSelectedWeapon != selectedWeapon)
            {
                SelectWeapon();
            }
        }
    }

    private void SelectWeapon()
    {
        if (pauseScreenScript.isPaused == false)
        {
            int i = 0;
            foreach (Transform weapon in transform)
            {
                if (i == selectedWeapon)
                    weapon.gameObject.SetActive(true);
                else
                    weapon.gameObject.SetActive(false);
                i++;
            }
            audioManagerScript.Play(switchSound);
        }
    }
}
