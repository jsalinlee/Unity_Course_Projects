using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float padding = 5.6f;
	public float movementSpeed;
	public float spawnDelay = 0.5f;

	private float xmin;
	private float xmax;

	private bool movingRight = true;

	// Use this for initialization
	void Start () {
		SpawnUntilFull();
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		xmin = leftmost.x + (0.5f * width);
		xmax = rightmost.x - (0.5f * width);
	}
	
	// Update is called once per frame
	void Update () {
		if (movingRight) {
			transform.position += Vector3.right * movementSpeed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * movementSpeed * Time.deltaTime;
		}
		if (transform.position.x >= xmax) {
			movingRight = false;
		} else if (transform.position.x <= xmin) {
			movingRight = true;
		}
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);

		if(AllMembersDead()) {
			Debug.Log("Empty Formation");
			SpawnUntilFull();
		}
	}

	Transform NextFreePosition() {
		foreach(Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount == 0) {
				return childPositionGameObject;
			}
		}
		return null;
	}

	bool AllMembersDead() {
		foreach(Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}

	void SpawnEnemies() {
		foreach( Transform child in transform) {
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	void SpawnUntilFull() {
		Transform freePosition = NextFreePosition();
		if(freePosition) {
			GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}
		if(NextFreePosition()) {
			Invoke("SpawnUntilFull", spawnDelay);
		}
	}

	public void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
	}
}
