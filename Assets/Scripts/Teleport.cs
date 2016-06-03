using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{

	public string[] maze;
	// Use this for initialization
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			int i = Random.Range(0, maze.Length);
			SceneManager.LoadScene(maze[i]);
		}
	}
}
