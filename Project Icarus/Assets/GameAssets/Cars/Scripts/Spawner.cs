using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public Transform HifiCartruck;
	public Transform HifiCartruckBlack;
	public Transform HifiCartruckBrown;
	public Transform HifiCarShingle;
	public Transform HifiCarShingleBlue;
	public Transform HifiCarShingleGold;
	public Transform MustangGreen;
	public Transform MustangYellow;
	public Transform MustangRed;
	public Transform MustangBlack;
	private Transform[] HifiCar = new Transform[10];
	public Transform LowfiCarGreen;
	public Transform LowfiCarRed;
	public Transform LowfiCarYellow;
	public Transform LowfiCarBrown;
	public Transform LowfiCarBlack;
	public Transform LowfiCarSilver;
	public Transform LowfiCarWhite;
	public Transform LowfiCarGrey;
	public Transform LowfiCarBlue;
	public Transform LowfiCarOrange;
	private Transform[] LowfiCar = new Transform[10];
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
		LowfiCar[3] = LowfiCarBrown;
		LowfiCar[4] = LowfiCarBlack;
		LowfiCar[5] = LowfiCarSilver;
		LowfiCar[6] = LowfiCarWhite;
//		LowfiCar[7] = LowfiCarGrey;
//		LowfiCar[8] = LowfiCarBlue;
//		LowfiCar[9] = LowfiCarOrange;

		HifiCar[0] = MustangGreen;
		HifiCar[1] = MustangYellow;
		HifiCar[2] = MustangRed;
		HifiCar[3] = MustangBlack;
		HifiCar[4] = HifiCartruck;
		HifiCar[5] = HifiCartruckBlack;
		HifiCar[6] = HifiCartruckBrown;
//		HifiCar[7] = HifiCarShingle;
//		HifiCar[8] = HifiCarShingleGold;
//		HifiCar[9] = HifiCarShingleBlue;

//		if(sceneName == "LoFi Scene")
//		{
//			car = LowfiCar[whatmodelCar];
//		}
//		else
//		{
//			car = HifiCar[whatmodelCar];
//		}

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
		whatmodelCar = Random.Range (0,7);
		//Debug.Log(whatmodelCar);
		if(sceneName == "LoFi Scene")
		{
			car = LowfiCar[whatmodelCar];
		}
		else
		{
			car = HifiCar[whatmodelCar];
		}

		//making timer that spawns car.
		if (timer < Time.time) 
		{
			randomSpawn = Random.Range (0, 12);
			Instantiate(car,spawnPoints[randomSpawn],Quaternion.identity);
			timer = Time.time + 2;
		}

	
	}
}
