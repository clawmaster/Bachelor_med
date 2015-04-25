using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public float waitingTime;

	private float currentTime;

	void Start () {

		waitingTime = Time.time + waitingTime;

	}
	
	void Update () {

		if (Time.time > waitingTime)
		{

			Application.LoadLevel("LoFi Scene");

		}

	}
}
