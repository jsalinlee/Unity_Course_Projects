using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;

	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable;

	void Start () {
		isBreakable = (this.tag == "Breakable");
		timesHit = 0;
		if (isBreakable) {
			breakableCount++;
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint(crack, transform.position);
		if (isBreakable) {
			HandleHits();
		}
	}

	void HandleHits () {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			Debug.Log(breakableCount);
			levelManager.BrickDestroyed();
			PuffSmoke();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}

	void PuffSmoke () {
			GameObject puff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
			ParticleSystem.MainModule main = puff.GetComponent<ParticleSystem>().main;
			main.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}

	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}

	// TODO Remove this method once we can actually win!
	void SimulateWin () {
		levelManager.LoadNextLevel();
	}

}