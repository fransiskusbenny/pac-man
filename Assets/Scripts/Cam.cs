using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour
{
	public Transform target;

	float camPosX = 18f;
	float camPosZ = 21f;

	void Update()
	{
		float xPos = target.position.x;
		float zPos = target.position.z;
        
		transform.position = new Vector3(xPos + camPosX, transform.position.y, zPos - camPosZ);
	}
}
