using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script that makes the camera follow the player

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject objectToFollow;
    private GameObject player;
    private Vector3 offset;

    //Calculates how far away the players is from the camera
    private void Start()
    {
        offset = transform.position - objectToFollow.transform.position;
    }

    //Moves the camera to the location of the player
    private void Update()
    {
        player = GameManager.Instance.GetPlayer();

       /* if (player != null) //miks t‰‰ kuseee?? jos tapan vihollisen niin kamera ei liiku en‰‰. mit‰?? ei mit‰‰n j‰rke‰..
        {*/

            transform.position = objectToFollow.transform.position + offset;
     //   }
    }
}