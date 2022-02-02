using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public GameObject objectToFollow;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - objectToFollow.transform.position;
    }

    void LateUpdate()
    {
        transform.position = objectToFollow.transform.position + offset;
    }
}