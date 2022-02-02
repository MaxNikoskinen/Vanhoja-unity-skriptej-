using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    private float xRotation = 0f;

    private PauseScreen pauseScreenScript;
    private PlayerMovement playerMovementScript;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseScreenScript = GameObject.FindObjectOfType<PauseScreen>();
        playerMovementScript = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if(pauseScreenScript.isPaused == false && playerMovementScript.isDead == false)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.unscaledDeltaTime;
            float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.unscaledDeltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
