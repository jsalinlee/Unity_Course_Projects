using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject laserPrefab;
	public float movementSpeed;
	public float padding = 1f;
	public float laserSpeed;
	public float firingRate = 0.2f;

	float xmin;
	float xmax;

	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
	}

	void Fire() {
		Vector3 laserPosition = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
		GameObject laser = Instantiate(laserPrefab, laserPosition, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
	}

	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * movementSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * movementSpeed * Time.deltaTime;
		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating("Fire", 0.0000001f, firingRate);
		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke("Fire");
		}

		// Restrict the player to the gamespace
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
}
