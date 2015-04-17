using UnityEngine;
using System.Collections;

public class Driving : MonoBehaviour {

	public Transform mover; //the object being moved
	private int speed = 10;
	public float SnapTo = 0.5f; //how close we get before snapping to the desination
	private Vector3 destination = Vector3.zero; //where we want to move
	private RaycastHit objectHit; //uses a ray forward preventing movement if hitting something.

	// possible movement patterns.
	private int groupCars;
	private int directionZ;
	private int directionX;
	private Vector3[] NextCheckpoint;
	private Vector3[] driveStraight = new Vector3[1];
	private Vector3[] driveLeft = new Vector3[5];
	private Vector3[] driveRight = new Vector3[5];
	private int currentCheckPoint = 0;

	//Corutine checks every 3 second if car have moved proberly far enough.
	private Vector3 coOldPosition;
	private float timer;

	// Use this for initialization
	void Start () {
		// binds this car to the script
		mover = this.transform;
		if (mover.position.z > 0) 
		{
			directionZ = -1;
		} else 
		{
			directionZ = 1;
		}
		if (mover.position.x > 0) 
		{
			directionX = -1;
		} else 
		{
			directionX = 1;
		}

		if (mover.position.z < 0 && mover.position.x < 0 || mover.position.z > 0 && mover.position.x > 0) 
		{ // for cars spawning in inner lanes.
			//Debug.Log("im driving in inner lane");
			driveStraight [0] = new Vector3 (0 * directionX + mover.position.x, 0, 305 * directionZ + mover.position.z);
			//Driving in a U, going right at incection 2
			driveLeft [0] = new Vector3 (0 * directionX + mover.position.x, 0, 135 * directionZ + mover.position.z);
			driveLeft [1] = new Vector3 (17 * directionX + mover.position.x, 0, 137 * directionZ + mover.position.z);
			driveLeft [2] = new Vector3 (277 * directionX + mover.position.x, 0, 138 * directionZ + mover.position.z);
			driveLeft [3] = new Vector3 (281 * directionX + mover.position.x, 0, 161 * directionZ + mover.position.z);
			driveLeft [4] = new Vector3 (281 * directionX + mover.position.x, 0, 280 * directionZ + mover.position.z);
			//Driving right at the 2nd intersection
			driveRight [0] = new Vector3 (0 * directionX + mover.position.x, 0, 135 * directionZ + mover.position.z);
			driveRight [1] = new Vector3 (17 * directionX + mover.position.x, 0, 137 * directionZ + mover.position.z);
			driveRight [2] = new Vector3 (268 * directionX + mover.position.x, 0, 138 * directionZ + mover.position.z);
			driveRight [3] = new Vector3 (266 * directionX + mover.position.x, 0, 129 * directionZ + mover.position.z);
			driveRight [4] = new Vector3 (266 * directionX + mover.position.x, 0, 0 * directionZ + mover.position.z);
		} 
		else //for cars spawning in outer lanes
		{
			//Driving straight ahead
			driveStraight [0] = new Vector3 (0 * directionX + mover.position.x, 0, 305 * directionZ + mover.position.z);
			//Driving in a U, going left at incection 2
			driveLeft [0] = new Vector3 (0 * directionX + mover.position.x, 0, 149 * directionZ + mover.position.z);
			driveLeft [1] = new Vector3 (34 * directionX + mover.position.x, 0, 152 * directionZ + mover.position.z);
			driveLeft [2] = new Vector3 (293 * directionX + mover.position.x, 0, 152 * directionZ + mover.position.z);
			driveLeft [3] = new Vector3 (297 * directionX + mover.position.x, 0, 140 * directionZ + mover.position.z);
			driveLeft [4] = new Vector3 (297 * directionX + mover.position.x, 0, 0 * directionZ + mover.position.z);
			//Driving right at the 2nd intersection
			driveRight [0] = new Vector3 (0 * directionX + mover.position.x, 0, 149 * directionZ + mover.position.z);
			driveRight [1] = new Vector3 (34 * directionX + mover.position.x, 0, 152 * directionZ + mover.position.z);
			driveRight [2] = new Vector3 (279 * directionX + mover.position.x, 0, 152 * directionZ + mover.position.z);
			driveRight [3] = new Vector3 (281 * directionX + mover.position.x, 0, 163 * directionZ + mover.position.z);
			driveRight [4] = new Vector3 (281 * directionX + mover.position.x, 0, 305 * directionZ + mover.position.z);

		}

		// adjusting for group cars (there is 3 roads systems, which is dedicated to current car cased on group)
		groupCars = Random.Range (1, 4);
		switch (groupCars) {
		case 1:
			NextCheckpoint = driveStraight;
			break;
		case 2:
			NextCheckpoint = driveLeft;
			break;
		case 3:
			NextCheckpoint = driveRight;
			break;
		default:
			Debug.Log("There was problem and car didnt get a group");
			Destroy (this.gameObject);
			break;
		}

		//Debug.Log(" groupcars: " + groupCars);
		
		destination = mover.position; //set the destination to the objects position when the script is run the first time

		//providing it with the wanted way of going.
		destination = NextCheckpoint[0];

		this.transform.LookAt(destination);

		// giving a small difference in car speeds
		speed = speed + Random.Range(0,4);
		// corutine checking if car is not moving forward as it should.
		coOldPosition = mover.position;
		timer = Time.time + 5;
		StartCoroutine(isMoving(mover));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//accelerate the car.
		//Debug.Log (Mathf.Abs(Vector3.Distance(destination,mover.position)));
//		if (Vector3.Distance(destination,mover.position) > 25.0 && speed < 30) 
//		{
//			speed = speed + 1;
//		} 
//		else if (speed > 5) 
//		{
//			speed = speed - 1;
//		}
			//makes character look at mouse
		Vector3 newRotation = Quaternion.LookRotation(destination - mover.position).eulerAngles;
		newRotation.x = 0;
		newRotation.z = 0;
		newRotation.y = newRotation.y - 180;
		Quaternion QnewRotation = Quaternion.Euler(newRotation);
		//Bringing car to stop if need to turn. 
//		if (mover.rotation != QnewRotation) 
//		{
//			speed = 5;
//		}
		mover.rotation = Quaternion.Lerp(mover.rotation,QnewRotation,Time.deltaTime * speed);

		//check for giving a new checkpoint.
		if (mover.position == destination)
		{
			//Debug.Log("length of checkpoints: " + NextCheckpoint.Length + " CurrentCheckpoint: " + currentCheckPoint);
			currentCheckPoint = currentCheckPoint + 1;	
			if(NextCheckpoint.Length > currentCheckPoint)
				{
					destination = NextCheckpoint[currentCheckPoint];
				}
				else
				{
					Destroy (this.gameObject);
					this.enabled=false;
					//Debug.Log ("a car have been removed");
				}

		}

		// moves the object.
		Debug.DrawRay(transform.position, -transform.forward*10, Color.green);
		if (Vector3.Distance (mover.position, destination) < SnapTo) { //are we within snap range?
			mover.position = destination; //snap to destination
		}
		else if (Physics.Raycast(transform.position, -transform.forward, out objectHit, 10)) 
		{
			Debug.Log("Raycast hitted to: " + objectHit.collider);
			//speed = 0;
		}
		else
		{
			if(speed == 0)
			{
				speed = 8;
			}
			transform.Translate(Vector3.back * Time.deltaTime*speed);
			//mover.position = Vector3.MoveTowards (mover.transform.position, destination, Time.deltaTime * speed); //move toward destination
		}
	
	}
	//CoRutine 
	IEnumerator isMoving(Transform car)
	{
		while(true)
		{

			if(timer < Time.time)
			{
				//Debug.Log("ive started corutine");
				if(Vector3.Distance(car.position,coOldPosition)<10)
					{
					Destroy (this.gameObject);
					this.enabled=false;
					}
				coOldPosition = car.position;
			}
			yield return new WaitForSeconds(6f);
		}
	}
}
