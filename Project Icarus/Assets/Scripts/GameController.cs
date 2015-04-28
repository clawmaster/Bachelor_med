using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public string sceneToLoad;
	public float sceneDuration;
	public float introTiming;
	public float SUDS1Timing;
	public float SUDS2Timing;
	public float outroTiming;

	public AudioClip introSound;
	public AudioClip SUDS1Sound;
	public AudioClip SUDS2Sound;
	public AudioClip outroSound;

	private float currentTime;
	private bool introPlaying = false;
	private bool SUDS1Playing = false;
	private bool SUDS2Playing = false;
	private bool outroPlaying = false;

	void Start () {

		sceneDuration = Time.time + sceneDuration;
		introTiming = Time.time + introTiming;

	}
	
	void Update () {

		if (Time.time > sceneDuration)
		{

			Application.LoadLevel(sceneToLoad);

		}

		if (Time.time > introTiming && introPlaying == false)
		{
			
			GetComponent<AudioSource>().PlayOneShot (introSound);
			introPlaying = true;
		}

		if (Time.time > SUDS1Timing && SUDS1Playing == false)
		{
			
			GetComponent<AudioSource>().PlayOneShot (SUDS1Sound);
			SUDS1Playing = true;
		}

		if (Time.time > SUDS2Timing && SUDS2Playing == false)
		{
			
			GetComponent<AudioSource>().PlayOneShot (SUDS2Sound);
			SUDS2Playing = true;
		}

		if (Time.time > outroTiming && outroPlaying == false)
		{
			
			GetComponent<AudioSource>().PlayOneShot (outroSound);
			outroPlaying = true;
		}

	}
	
}
