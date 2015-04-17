using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public Transform HifiCar;
	public Transform LowfiCarGreen;
	public Transform LowfiCarRed;
	public Transform LowfiCarYellow;
	private Transform[] LowfiCar = new Transform[3];
	public Transform car;
	private int whatmodelCar;
	private Vector3[] spawnPoints = new Vector3[12];
	private float timer;
	private int randomSpawn;
	public string sceneName;


	// Use this for initialization
	void Start () {

		Debug.Log (Application.loadedLevelName);
		sceneName = Application.loadedLevelName;
		
		LowfiCar[0] = LowfiCarGreen;
		LowfiCar[1] = LowfiCarRed;
		LowfiCar[2] = LowfiCarYellow;

		if(sceneName == "LoFi Scene")
		{
			car = LowfiCar[whatmodelCar];
		}
		else
		{
			car = HifiCar;
		}

		//outer lane spawn
		spawnPoints [0] = new Vector3 (-123, 0, 149);
		spawnPoints [1] = new Vector3 (-118, 0, 154);
		spawnPoints [2] = new Vector3 (-112, 0, 159);

		spawnPoints [3] = new Vector3 (184, 0, -130);
		spawnPoints [4] = new Vector3 (179, 0, -135);
		spawnPoints [5] = new Vector3 (174, 0, -140);

		// inner lane spawns
		spawnPoints [6] = new Vector3 (168, 0, 150);
		spawnPoints [7] = new Vector3 (163, 0, 154);
		spawnPoints [8] = new Vector3 (159, 0, 158);

		spawnPoints [9] = new Vector3 (-108, 0, -132);
		spawnPoints [10] = new Vector3 (-103, 0, -136);
		spawnPoints [11] = new Vector3 (-98, 0, -140);

		timer = Time.time+3;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
// spawning Cars prefab randomly.
		whatmodelCar = Random.Range (0,3);
		//Debug.Log(whatmodelCar);
		if(sceneName == "LoFi Scene")
		{
			car = LowfiCar[whatmodelCar];
		}
		else
		{
			car = HifiCar;
		}

		//making timer that spawns car.
		if (timer < Time.time) 
		{
			randomSpawn = Random.Range (0, 12);
			Instantiate(car,spawnPoints[randomSpawn],Quaternion.identity);
			timer = Time.time + 1;
		}

	
	}
}
