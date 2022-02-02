using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject prefabToSpawn2;

    void OnMouseDown()
    {
        Destroy(gameObject);

        //Sprite
        GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
        newObject.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);

        //Sound
        GameObject newObject2 = Instantiate<GameObject>(prefabToSpawn2);
        newObject2.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
    }
}
