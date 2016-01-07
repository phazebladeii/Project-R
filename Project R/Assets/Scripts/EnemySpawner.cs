using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public float[] x_coords = {-3.414f, -0.081f};
	public float[] y_coords = {-4.818f, -7.63f};
	private float x, y;

	public GameObject enemyPrefab;
	GameObject enemyClone;
	private int currId = 0;
	public float spawnTimes = 15f;
	public int numberOfMobs = 10; // The max number of mobs this map should handle
	private int mobCounter = 1;

	// Use this for initialization
	void Start () {
		
		// Instantiate the enemy given the coordinates
		InvokeRepeating("Spawner", spawnTimes, spawnTimes);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawner() {
		if (mobCounter <= numberOfMobs) {
			CreateNewEnemy();
			print("New ENEMY [" + currId + "] @ " + x + ", " + y);
			mobCounter++;
			currId++;
		} else { print("Reached map mob limit"); CancelInvoke("Spawner"); }
	}

	private void CreateNewEnemy() {
		Calculate();
		enemyClone = Instantiate(enemyPrefab, new Vector2(x, y), Quaternion.identity) as GameObject;
		enemyClone.GetComponent<ObjectSheet>().id = currId;

	}

	private void Calculate() {
		x = Random.Range(x_coords[0], x_coords[1]);
		y = Random.Range(y_coords[0], y_coords[1]);
	}
}
