using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;
    
    void Start() {
        if (autoLoadNextLevelAfter == 0) {
            Debug.Log("Level auto load diabled");
        } else {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }

    public void LoadLevel(string name) {
		SceneManager.LoadScene(name);
	}

	public void QuitRequest() {
		Debug.Log("Quit requested");
		Application.Quit();
	}

	public void LoadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}

