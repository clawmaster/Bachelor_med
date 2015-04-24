using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public float waitingTime = 15f;

	private float currentTime;

	// Use this for initialization
	void Start () {

		waitingTime = Time.time + waitingTime;

	}
	
	// Update is called once per frame
	void Update () {

		currentTime = Time.time;

		if (currentTime > waitingTime){
			Application.LoadLevel("LoFi Scene");
		}
	
	}
}
