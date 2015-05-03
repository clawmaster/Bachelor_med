using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public Vector3 goal;
	NavMeshAgent agent;
	private Vector3 lastPos = new Vector3(0,0,0);
	private int counter;

	// Use this for initialization
	void Start () {
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		if (transform.position.z > 0)
		{
			if(transform.position.x > 185 || transform.position.x < -125) 
				goal = transform.position + new Vector3(0,0,-200f);
			else if (transform.position.x > 150 && transform.position.x < 185)
				goal = transform.position + new Vector3(-248,0,0);
			else 
				goal = transform.position + new Vector3(248,0,0);
		}
		else
		{
			if(transform.position.x > 185 || transform.position.x < -125) 
				goal = transform.position + new Vector3(0,0,200f);
			else if (transform.position.x > 150 && transform.position.x < 185)
				goal = transform.position + new Vector3(-248,0,0);
			else 
				goal = transform.position + new Vector3(248,0,0);
		}



		agent.destination = goal;
	}
	
	// Update is called once per frame
	void Update () {
		if (lastPos == transform.position) {
			counter++;
		}
		else 
		{
			counter = 0;
		}
		if(counter > 20)
		{
			Destroy(this.gameObject);
		}

		lastPos = transform.position;

	
	}
}
