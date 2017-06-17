using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log("Load request for level, " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest() {
		Debug.Log("Quit requested");
		Application.Quit();
	}
}

