using UnityEngine;
using System.Collections;

public class ExposureController : MonoBehaviour {

	public string sceneToLoad;
	public float sceneDuration;
	public float introTiming;
	public float SUDS1Timing;
	public float SUDS2Timing;
	public float SUDS3Timing;
	public float SUDS4Timing;
	public float SUDS5Timing;
	public float SUDS6Timing;
	public float SUDS7Timing;
	public float SUDS8Timing;
	public float SUDS9Timing;
	public float outroTiming;

	public AudioClip introSound;
	public AudioClip SUDS1Sound;
	public AudioClip SUDS2Sound;
	public AudioClip SUDS3Sound;
	public AudioClip SUDS4Sound;
	public AudioClip SUDS5Sound;
	public AudioClip SUDS6Sound;
	public AudioClip SUDS7Sound;
	public AudioClip SUDS8Sound;
	public AudioClip SUDS9Sound;
	public AudioClip outroSound;

	private float currentTime;
	private bool introPlaying = false;
	private bool SUDS1Playing = false;
	private bool SUDS2Playing = false;
	private bool SUDS3Playing = false;
	private bool SUDS4Playing = false;
	private bool SUDS5Playing = false;
	private bool SUDS6Playing = false;
	private bool SUDS7Playing = false;
	private bool SUDS8Playing = false;
	private bool SUDS9Playing = false;
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
		
		if (Time.time > SUDS3Timing && SUDS3Playing == false)
		{
			
			GetComponent<AudioSource>().PlayOneShot (SUDS3Sound);
			SUDS3Playing = true;
		}
		
		if (Time.time > SUDS4Timing && SUDS4Playing == false)
		{
			
			GetComponent<AudioSource>().PlayOneShot (SUDS4Sound);
			SUDS4Playing = true;
		}
		
		if (Time.time > SUDS5Timing && SUDS5Playing == false)
		{
			
			GetComponent<AudioSource>().PlayOneShot (SUDS5Sound);
			SUDS5Playing = true;
		}
		
		if (Time.time > SUDS6Timing && SUDS6Playing == false)
		{
			
			GetComponent<AudioSource>().PlayOneShot (SUDS6Sound);
			SUDS6Playing = true;
		}
		
		if (Time.time > SUDS7Timing && SUDS7Playing == false)
		{
			
			GetComponent<AudioSource>().PlayOneShot (SUDS7Sound);
			SUDS7Playing = true;
		}
		
		if (Time.time > SUDS8Timing && SUDS8Playing == false)
		{
			
			GetComponent<AudioSource>().PlayOneShot (SUDS8Sound);
			SUDS8Playing = true;
		}
		
		if (Time.time > SUDS9Timing && SUDS9Playing == false)
		{
			
			GetComponent<AudioSource>().PlayOneShot (SUDS9Sound);
			SUDS9Playing = true;
		}

		if (Time.time > outroTiming && outroPlaying == false)
		{
			
			GetComponent<AudioSource>().PlayOneShot (outroSound);
			outroPlaying = true;
		}

	}
	
}
