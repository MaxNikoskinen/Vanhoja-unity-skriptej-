using System.Collections;
using UnityEngine;

public class GasCanister : MonoBehaviour
{
    private GasSystem gasSystem;
    public GameObject soundPrefab;

    private void Start()
    {
        gasSystem = GameObject.FindObjectOfType<GasSystem>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (gasSystem.isGameOver == false)
        {
            if (otherCollider.CompareTag("Player"))
            {

                gasSystem.RefillGas();
                GameObject newObject = Instantiate<GameObject>(soundPrefab);
                newObject.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
                Destroy(gameObject);
            }
        }
        else return;
    }
}
