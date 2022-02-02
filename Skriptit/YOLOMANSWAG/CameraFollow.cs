using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject objectToFollow;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - objectToFollow.transform.position;
    }

    private void Update()
    {
        transform.position = objectToFollow.transform.position + offset;
    }
}
