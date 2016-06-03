using UnityEngine;
using System.Collections;

public class GhostFrigthened : MonoBehaviour
{

	Renderer[] child;
	public float ghostValue = 50f;
	public Material prevMat;
	public bool isFrigthened;

	void Start()
	{
		child = GetComponentsInChildren<Renderer>();
		isFrigthened = false;
	}

	public void FrigthenedMaterial()
	{
		isFrigthened = true;
		foreach (Renderer i in child) {
			i.material.color = Color.blue;
		}
	}

	public void NormalMaterial()
	{
		isFrigthened = false;
		foreach (Renderer i in child) {
			i.material = prevMat;
		}

	}

	void OnTriggerEnter(Collider col)
	{
		if (isFrigthened) {
			if (col.tag == "Player") {
				Player.score += (ghostValue * Player.bonus);
				Destroy(transform.gameObject);
			}
		}
	}
}
