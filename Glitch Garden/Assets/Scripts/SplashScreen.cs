using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour {
    LevelManager levelManager;
    float timer = 2.5f;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            levelManager.LoadLevel("Start");
        }
    }
}
