﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	[SerializeField]
	private string m_animationPropertyName;

	[SerializeField]
	private GameObject m_initialScreen;

	[SerializeField]
	private List<GameObject> m_navigationHistory;
	GameObject[] pauseMenu;

	void Start()
	{
		pauseMenu = GameObject.FindGameObjectsWithTag("PauseMenu");
	}

	public void GoBack()
	{
		if (m_navigationHistory.Count > 1) {
			int index = m_navigationHistory.Count - 1;
			Animate(m_navigationHistory[index - 1], true);

			GameObject target = m_navigationHistory[index];
			m_navigationHistory.RemoveAt(index);
			Animate(target, false);
		}
	}

	public void GoToMenu(GameObject target)
	{
		if (target == null) {
			return;
		}

		if (m_navigationHistory.Count > 0) {
			Animate(m_navigationHistory[m_navigationHistory.Count - 1], false);
		}

		m_navigationHistory.Add(target);
		Animate(target, true);
	}

	private void Animate(GameObject target, bool direction)
	{
		if (target == null) {
			return;
		}

		target.SetActive(true);

		Canvas canvasComponent = target.GetComponent<Canvas>();
		if (canvasComponent != null) {
			canvasComponent.overrideSorting = true;
			canvasComponent.sortingOrder = m_navigationHistory.Count;
		}

		Animator animatorComponent = target.GetComponent<Animator>();
		if (animatorComponent != null) {
			animatorComponent.SetBool(m_animationPropertyName, direction);
		}
	}

	private void Awake()
	{
		m_navigationHistory = new List<GameObject>{ m_initialScreen };
	}


	public string[] scenes;

	public void StartGame()
	{
		int random = Random.Range(0, scenes.Length);
		SceneManager.LoadScene(scenes[random]);
	}

	public void PausedGame()
	{
		Time.timeScale = 0;
		foreach (GameObject g in pauseMenu) {
			g.SetActive(true);
		}
	}

	public void ResumeGame()
	{
		Time.timeScale = 1;
		foreach (GameObject g in pauseMenu) {
			g.SetActive(false);
		}
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("00-Main Menu");
	}
		
}