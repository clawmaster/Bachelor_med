using UnityEngine;
using System.Collections;

public class Driving : MonoBehaviour {

	public Transform mover; //the object being moved
	public float SnapTo = 0.5f; //how close we get before snapping to the desination
	private Vector3 destination = Vector3.zero; //where we want to move

	// possible movement patterns.
	private Vector3[] NextCheckpoint = new Vector3[3];
	private int currentCheckPoint = 0;


	// Use this for initialization
	void Start () {
		mover = this.transform;
		destination = mover.position; //set the destination to the objects position when the script is run the first time
		NextCheckpoint[0] = new Vector3(-105,0,-105); NextCheckpoint[1] = new Vector3(-105,0,0); NextCheckpoint[2] = new Vector3(0,0,0);

		//providing it with the wanted way of going.
		destination = NextCheckpoint[0];


	}
	
	// Update is called once per frame
	void Update () {

		//makes character look at mouse
		Vector3 newRotation = Quaternion.LookRotation(destination - mover.position).eulerAngles;
		newRotation.x = 0;
		newRotation.z = 0;
		newRotation.y = newRotation.y - 180;
		Quaternion QnewRotation = Quaternion.Euler(newRotation);
		mover.rotation = Quaternion.Lerp(mover.rotation,QnewRotation,Time.deltaTime*3);

		//check for giving a new checkpoint.
		if (mover.position == destination)
		{
			currentCheckPoint = currentCheckPoint + 1;
			if(NextCheckpoint.Length < currentCheckPoint)
				{
					Destroy (this.gameObject);
				}
			
			destination = NextCheckpoint[currentCheckPoint];
		}

		// moves the object.
		if (Vector3.Distance (mover.position, destination) < SnapTo) { //are we within snap range?
			mover.position = destination; //snap to destination
		}else
		{
			mover.position = Vector3.MoveTowards (mover.transform.position, destination, Time.deltaTime * 5); //move toward destination
		}
	
	}
}
