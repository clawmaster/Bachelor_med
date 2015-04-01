using UnityEngine;
using System.Collections;

public class Driving : MonoBehaviour {

	public Transform mover; //the object being moved
	private int speed = 0;
	public float SnapTo = 0.5f; //how close we get before snapping to the desination
	private Vector3 destination = Vector3.zero; //where we want to move

	// possible movement patterns.
	private int groupCars;
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
		//accelerate the car.
		Debug.Log (destination.x + destination.z);
		if (Mathf.Abs(mover.position.x + mover.position.z) - Mathf.Abs(destination.x + destination.z) > 25 && speed < 30) 
		{
			speed = speed + 1;
		} 
		else if (speed > 5) 
		{
			speed = speed - 1;
		}
			//makes character look at mouse
		Vector3 newRotation = Quaternion.LookRotation(destination - mover.position).eulerAngles;
		newRotation.x = 0;
		newRotation.z = 0;
		newRotation.y = newRotation.y - 180;
		Quaternion QnewRotation = Quaternion.Euler(newRotation);
		//Bringing car to stop if need to turn. 
		if (mover.rotation != QnewRotation) 
		{
			speed = 5;
		}
		mover.rotation = Quaternion.Lerp(mover.rotation,QnewRotation,Time.deltaTime * speed);

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
			mover.position = Vector3.MoveTowards (mover.transform.position, destination, Time.deltaTime * speed); //move toward destination
		}
	
	}
}
