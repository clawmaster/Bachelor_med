using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public float waitingTime;
	public float introTiming;
	public AudioClip introSound;

	private float currentTime;
	private bool introPlaying;

	void Start () {

		waitingTime = Time.time + waitingTime;
		introTiming = Time.time + introTiming;

	}
	
	void Update () {

		if (Time.time > waitingTime)
		{

			Application.LoadLevel("LoFi Scene");

		}

		if (Time.time > introTiming && introPlaying == false)
		{
			
			GetComponent<AudioSource>().PlayOneShot (introSound);
			introPlaying = true;
			
		}

	}
}
