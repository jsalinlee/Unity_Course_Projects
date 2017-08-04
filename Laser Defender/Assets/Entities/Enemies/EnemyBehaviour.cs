using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	public GameObject projectilePrefab;
	public float health = 150f;
	public float projectileSpeed;
	public float shotsPerSeconds = 0.5f;
	public int enemyPoints = 100;
	public AudioClip fireSound;
	public AudioClip deathSound;

	private Scoreboard scoreboard;

	void Start() {
		scoreboard = GameObject.Find("Canvas/Scoreboard").GetComponent<Scoreboard>();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if (missile) {
			health -= missile.GetDamage();
			missile.Hit();
			if (health <= 0) {
			Die();
			}
		}
	}

	void Fire() {
//		Vector3 projectilePosition = new Vector3(0, -0.7f, 0);
		GameObject laser = Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
		laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);
	}

	void Update() {
		float probability = Time.deltaTime * shotsPerSeconds;
		if (Random.value < probability) {
			Fire();
		}
	}

	void Die() {
		AudioSource.PlayClipAtPoint(deathSound, transform.position);
		scoreboard.Score(enemyPoints);
		Destroy(gameObject);
	}
}
