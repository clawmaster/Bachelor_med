using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public string sceneToLoad;
	public float sceneDuration = 120f;
	public float introTiming = 10f;
	public float SUDS1Timing = 50f;
	public float SUDS2Timing = 80f;
	public float outroTiming = 100f;

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

		sceneDuration = Time.timeSinceLevelLoad + sceneDuration;
		introTiming =  + introTiming;

	}
	
	void Update () {

		if (Time.timeSinceLevelLoad > sceneDuration)
		{

			Application.LoadLevel(sceneToLoad);

		}

		if (Time.timeSinceLevelLoad > introTiming && introPlaying == false)
		{
			
			GetComponent<AudioSource>().PlayOneShot (introSound);
			introPlaying = true;
		}

		if (Time.timeSinceLevelLoad > SUDS1Timing && SUDS1Playing == false)
		{
			
			GetComponent<AudioSource>().PlayOneShot (SUDS1Sound);
			SUDS1Playing = true;
		}

		if (Time.timeSinceLevelLoad > SUDS2Timing && SUDS2Playing == false)
		{
			
			GetComponent<AudioSource>().PlayOneShot (SUDS2Sound);
			SUDS2Playing = true;
		}

		if (Time.timeSinceLevelLoad > outroTiming && outroPlaying == false)
		{
			
			GetComponent<AudioSource>().PlayOneShot (outroSound);
			outroPlaying = true;
		}

	}
	
}
