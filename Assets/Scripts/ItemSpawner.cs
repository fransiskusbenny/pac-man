using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour
{
	ItemRules itemRules;

	public GameObject[] item;
	public Transform pos;
	public float itemSpawnDelay;


	void Start()
	{
		itemRules = new ItemRules();

		StartCoroutine(SpawnItem());
	}

	IEnumerator SpawnItem()
	{
		
		string itemsHolderName = "Items";
		GameObject itemsHolder = new GameObject(itemsHolderName);
		itemsHolder.transform.parent = transform;

		while (true) {
			int count = itemRules.Rule(Player.health, Player.bonus, Player.score);
			for (int i = 0; i < count; i++) {
				int randIndex = Random.Range(0, pos.childCount);
				Transform iPos = pos.GetChild(randIndex);
				GameObject t = Instantiate(item[i], iPos.position, Quaternion.identity) as GameObject;
				t.transform.name = "Item";
				t.transform.parent = itemsHolder.transform;
			}

			yield return new WaitForSeconds(itemSpawnDelay);
		}
	}
}
