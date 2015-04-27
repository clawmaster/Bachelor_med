using UnityEngine;
using System.Collections;

public class pedestrianSpawner : MonoBehaviour {

	public Transform pedestrian;
	private float timer;
	private int randomSpawn;

	private Vector3[] spawnPoints = new Vector3[8];

	// Use this for initialization
	void Start () {
		//minus side
		spawnPoints [0] = new Vector3 (-127f, 1.79f, -100f);
		spawnPoints [1] = new Vector3 (-94.8f, 1.79f,-100f);
		spawnPoints [2] = new Vector3 (153f, 1.79f, -100f);
		spawnPoints [3] = new Vector3 (187f, 1.79f, -100f);
		//plus side
		spawnPoints [4] = new Vector3 (-127f, 1.79f, 100f);
		spawnPoints [5] = new Vector3 (-94.8f, 1.79f, 100f);
		spawnPoints [6] = new Vector3 (153f, 1.79f, 100f);
		spawnPoints [7] = new Vector3 (187f, 1.79f, 100f);


		timer = Time.time+1;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (timer < Time.time) 
		{
			randomSpawn = Random.Range (0, 8);
			Instantiate(pedestrian,spawnPoints[randomSpawn],Quaternion.identity);
			timer = Time.time + 1;
		}
	}
}
