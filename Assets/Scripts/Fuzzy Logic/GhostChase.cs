using UnityEngine;
using System.Collections;
using UnityEditor;

public class GhostChase : MonoBehaviour
{

	BehaviorRules behaviorRules;
	Transform target;
	public float sightRadius;
	public LayerMask targetMask;
	Seeker seeker;

	GameObject[] waypoints;
	int waypointIndex;

	bool isChase;

	void Start()
	{
		behaviorRules = new BehaviorRules();

		seeker = GetComponent<Seeker>();
		target = GameObject.FindGameObjectWithTag("Player").transform as Transform;

		waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		StartCoroutine(CheckBehavior());
	}

	void Update()
	{
		float result = behaviorRules.Rule(1319, 69, 4.36f, 1706);
		if (result >= 0.34f && result < 0.67f) {
			isChase = true;
		} else {
			isChase = false;
		}
	}

	IEnumerator CheckBehavior()
	{
		while (true) {
			Debug.Log("Chase " + isChase);
			if (isChase)
				StartCoroutine(Chase(isChase));
			else
				StartCoroutine(Patrol(isChase));
			
			yield return new WaitForSeconds(10f);
		}
	}

	IEnumerator Chase(bool isChase)
	{
		while (isChase) {
			Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, sightRadius, targetMask);
			for (int i = 0; i < targetInViewRadius.Length; i++) {
				if (targetInViewRadius[i].tag == "Player") {
					seeker.StartPathing(target.position);
				} 


			}
			yield return new WaitForSeconds(0.5f);

		}
	}

	IEnumerator Patrol(bool isChase)
	{
		while (!isChase) {
			//Enamy Patrol
			waypointIndex = Random.Range(0, waypoints.Length);
			Transform waypoint = waypoints[waypointIndex].transform;
			//					float distance = Vector3.Distance(transform.position, target.position);
			//					if (distance < 500f) {
			//						seeker.StartPathing(target.position);
			//					}
			seeker.StartPathing(waypoint.position);

			yield return new WaitForSeconds(5f);
		}
	}

	void OnDrawGizmos()
	{
		UnityEditor.Handles.color = Color.white;
		UnityEditor.Handles.DrawWireArc(transform.position, Vector3.up, Vector3.forward, 360, sightRadius);
	}

}