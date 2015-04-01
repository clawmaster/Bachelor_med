using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public Transform car;
	private Vector3[] spawnPoints = new Vector3[6];
	private float timer;
	private int randomSpawn;


	// Use this for initialization
	void Start () {
		spawnPoints [0] = new Vector3 (-123, 0, 149);
		spawnPoints [1] = new Vector3 (-118, 0, 154);
		spawnPoints [2] = new Vector3 (-113, 0, 159);
		spawnPoints [3] = new Vector3 (-98, 0, -145);
		spawnPoints [4] = new Vector3 (-103, 0,-150);
		spawnPoints [5] = new Vector3 (-107, 0,-155);

		timer = Time.time+5;
	}
	
	// Update is called once per frame
	void Update () {

		if (timer < Time.time) 
		{
			randomSpawn = Random.Range (0, 6);
			Instantiate(car,spawnPoints[randomSpawn],Quaternion.identity);
			timer = Time.time + 5;
		}

	
	}
}
