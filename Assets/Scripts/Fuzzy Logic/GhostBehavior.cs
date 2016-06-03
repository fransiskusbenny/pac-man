using UnityEngine;
using System.Collections;
using UnityEditor;

public class GhostBehavior : MonoBehaviour
{

	BehaviorRules behaviorRules;
	Transform target;

	bool gameOver;

	public float sightRadius;
	public LayerMask targetMask;
	Seeker seeker;
	bool isGuard, isChase, isBrutal;
	float refreshRate = 5f;
	bool isInSight;


	GameObject[] waypoints;
	int waypointIndex;

	void Start()
	{
		behaviorRules = new BehaviorRules();

		seeker = GetComponent<Seeker>();
		target = GameObject.FindGameObjectWithTag("Player").transform as Transform;

		waypoints = GameObject.FindGameObjectsWithTag("Waypoint");

		StartCoroutine(CheckBehavior());
	}

	IEnumerator CheckBehavior()
	{
		while (true) {
			float result = behaviorRules.Rule(Player.distance, Player.health, Player.bonus, Player.score);
			if (result >= 0 && result <= 0.33f) {
				//guard
				GhostGuard();
			} else if (result >= 0.34f && result < 0.67f) {
				//chase area
				GhostChase();
			} else if (result >= 0.67f && result <= 1) {
				//brutal
				Brutal();
			}

			yield return new WaitForSeconds(3f);
		}
	}

	void GhostGuard()
	{
		isGuard = true;
		isChase = isBrutal = false;
		StartCoroutine(GhostGuardItems());
	}

	void GhostChase()
	{
		isChase = true;
		isGuard = isBrutal = false;
		StartCoroutine(GhostChasePlayer());
	}

	void Brutal()
	{
		isBrutal = true;
		isGuard = isChase = false;
		StartCoroutine(GhostBrutal());
	}

	IEnumerator GhostGuardItems()
	{
		while (isGuard) {
			seeker.StartPathing(ClosestItem().position);
//			Debug.Log("Guard");
			yield return new WaitForSeconds(refreshRate);
		}
	}

	IEnumerator GhostChasePlayer()
	{
		while (isChase) {
			Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, sightRadius, targetMask);
			for (int i = 0; i < targetInViewRadius.Length; i++) {
				if (targetInViewRadius[i].tag == "Player") {
//					Debug.Log("Chase");
					seeker.StartPathing(target.position);
				}
//				else {
//					//Enamy Patrol
//					waypointIndex = Random.Range(0, waypoints.Length);
//					Transform waypoint = waypoints[waypointIndex].transform;
//					float distance = Vector3.Distance(transform.position, target.position);
//					if (distance < 500f) {
//						seeker.StartPathing(target.position);
//					}
//					seeker.StartPathing(waypoint.position);
//				}
			}

			yield return new WaitForSeconds(refreshRate);
		}
	}

	IEnumerator GhostBrutal()
	{
		while (isBrutal) {
			seeker.StartPathing(target.position);
//			Debug.Log("Brutal");
			yield return new WaitForSeconds(refreshRate);
		}
	}

	Transform ClosestItem()
	{
		GameObject[] items;
		items = GameObject.FindGameObjectsWithTag("Item");
		Transform tmin = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPos = transform.position;
		foreach (GameObject t in items) {
			float dist = Vector3.Distance(t.transform.position, currentPos);
			if (dist < minDist) {
				tmin = t.transform;
				minDist = dist;
			}
		}
		return tmin;
	}

}

//	void OnDrawGizmos()
//	{
//		UnityEditor.Handles.color = Color.white;
//		UnityEditor.Handles.DrawWireArc(transform.position, Vector3.up, Vector3.forward, 360, sightRadius);
//	}

