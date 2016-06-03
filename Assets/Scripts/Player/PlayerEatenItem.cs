using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerEatenItem : MonoBehaviour
{

	PlayerMove playerMove;
	public Slider itemDurationSlider;
	public Image fill;

	public float itemSpeedIncrease;
	public float itemSpeedDuration;

	public float itemFreezeDuration;
	public float itemPowerDuration;

	public float healthIncreaseMin;
	public float healthIncreaseMax;

	bool freeze, power, speed = false;

	GameObject[] ghosts;

	void Start()
	{
		playerMove = GetComponent<PlayerMove>();
	}

	void FixedUpdate()
	{
		if (speed || freeze || power) {
			itemDurationSlider.enabled = true;
			itemDurationSlider.value -= Time.fixedDeltaTime;

			if (itemDurationSlider.value == 0)
				itemDurationSlider.enabled = false;
		}
//		else if (freeze)
//			itemDurationSlider.value -= Time.fixedDeltaTime;
//		else if (power)
//			itemDurationSlider.value -= Time.fixedDeltaTime;
	}

	void OnTriggerEnter(Collider other)
	{
		ghosts = GameObject.FindGameObjectsWithTag("Ghost");

		if (other.gameObject.tag == "Item Speed") {
			IncreaseMoveSpeed();
		} else if (other.gameObject.tag == "Item Freeze") {
			FreezeGhostMovement();
		} else if (other.gameObject.tag == "Item Power") {
			FrigthenedGhost();
		} else if (other.gameObject.tag == "Item Health") {
			Player.health += Mathf.RoundToInt(Random.Range(healthIncreaseMin, healthIncreaseMax));
		}
	}

	void IncreaseMoveSpeed()
	{
		fill.color = Color.gray;
		itemDurationSlider.value = itemSpeedDuration;
		itemDurationSlider.maxValue = itemSpeedDuration;
		speed = true;
		playerMove.moveSpeed += itemSpeedIncrease;
		StartCoroutine(StopSpeed(itemSpeedDuration));
	}

	IEnumerator StopSpeed(float duration)
	{
		yield return new WaitForSeconds(duration);
		playerMove.moveSpeed -= itemSpeedIncrease;
		speed = false;
	}

	void FreezeGhostMovement()
	{
		fill.color = Color.cyan;
		itemDurationSlider.value = itemFreezeDuration;
		itemDurationSlider.maxValue = itemFreezeDuration;
		freeze = true;
		foreach (GameObject g in ghosts) {
			g.GetComponent<Seeker>().speed = 0;
		}
		StartCoroutine(StopFreeze(itemFreezeDuration));
	}

	IEnumerator StopFreeze(float duration)
	{
		yield return new WaitForSeconds(duration);
		foreach (GameObject g in ghosts) {
			g.GetComponent<Seeker>().speed = 3f;
		}
		freeze = false;
	}

	void FrigthenedGhost()
	{
		fill.color = Color.blue;
		itemDurationSlider.value = itemPowerDuration;
		itemDurationSlider.maxValue = itemPowerDuration;
		power = true;
		foreach (GameObject g in ghosts) {
			if (g)
				g.GetComponent<GhostFrigthened>().FrigthenedMaterial();
		}

		StartCoroutine(StopFrigthened(itemPowerDuration));
	}

	IEnumerator StopFrigthened(float duration)
	{
		yield return new WaitForSeconds(duration);
		foreach (GameObject g in ghosts) {
			if (g)
				g.GetComponent<GhostFrigthened>().NormalMaterial();
		}
		power = false;
	}
}
