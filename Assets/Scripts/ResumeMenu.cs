﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeMenu : MonoBehaviour {

	public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;

	// Update is called once per frame
	void Update () {
		bool esc = Input.GetKeyDown (KeyCode.Escape);

		if (esc) {
			if (GameIsPaused) {
				Resume();
			} else {
				Pause();
			}
		}
	}

	public void Resume(){
		PauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void Pause(){
		PauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void QuitGame(){
		Application.Quit();
	}
}
