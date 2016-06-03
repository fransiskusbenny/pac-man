using UnityEngine;
using System.Collections;

public class GhostSpawner : MonoBehaviour
{

	public GameObject[] ghosts;
	public Transform pellets;

	void Start()
	{
		string ghostsHolderName = "Ghosts";
		GameObject ghostHolder = new GameObject(ghostsHolderName);
		ghostHolder.transform.parent = transform;

		for (int g = 0; g < ghosts.Length; g++) {
			int randIndex = Random.Range(0, pellets.childCount);
			GameObject t = Instantiate(ghosts[g], pellets.GetChild(randIndex).position, Quaternion.identity) as GameObject;

			t.transform.name = "Ghost";
			t.transform.parent = ghostHolder.transform;
		}
	}
}
