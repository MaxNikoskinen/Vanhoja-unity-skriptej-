using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
	public int moneyToAddAmount = 1;
    private CoinSystem moneySystem;
    public GameObject soundPrefab;

    private void Start()
    {
        moneySystem = GameObject.FindObjectOfType<CoinSystem>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
	{
        if (otherCollider.CompareTag("Player"))
		{
            moneySystem.AddPoints(moneyToAddAmount);
            GameObject newObject = Instantiate<GameObject>(soundPrefab);
            newObject.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
            Destroy(gameObject);
        }
	}
}
