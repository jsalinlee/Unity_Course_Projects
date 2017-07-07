﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {
	public int score = 0;
	private Text scoreText;

	void Start() {
		scoreText = GetComponent<Text>();
		Reset();
	}

	public void Score(int points) {
		score += points;
		scoreText.text = score.ToString();
	}

	public void Reset() {
		score = 0;
		scoreText.text = score.ToString();
	}
}
