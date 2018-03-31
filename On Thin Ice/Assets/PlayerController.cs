using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

	public Rigidbody rigidbody;
	public float speed = 13f;
	public float accelleration = 10f;
	public SphereCollider sCol;
	public GameObject Collider;

	private float maxSpeed = .3f;
	private float accelMagnitude = .01f;

	private float Forward;
	private float Turn;
	private float Brake;

	private Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}

	
	public int lastCheckpointPassed = 0;

    public LapManager lapManager;

	// Update is called once per frame
	void Update () {
		Vector3 dir = new Vector3(-Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal"));
		dir = dir.normalized * speed;
		//rigidbody.velocity = vel;

		//Vector3 lookDirection = new Vector3()
		transform.LookAt(transform.position - dir);

		rigidbody.AddForce(transform.rotation * new Vector3(-1f, 0f, 0f) * accelleration  * Time.deltaTime);

		if(rigidbody.velocity.magnitude > speed){ rigidbody.velocity = rigidbody.velocity.normalized * speed;}

		//rigidbody.velocity = transform.rotation * new Vector3(-1f, 0f, 0f) * speed ;
	}

	public void passCheckpoint(Checkpoint checkpoint){
		Debug.Log(this.name + " passed checkpoint " + checkpoint.checkpointNumber);

		if(lastCheckpointPassed == checkpoint.totalNumberOfCheckpoints - 1 && checkpoint.checkpointNumber == 0){
			lastCheckpointPassed = 0;
			finishedLap();
		}
		else if(lastCheckpointPassed == checkpoint.checkpointNumber - 1){
			lastCheckpointPassed++;
		}

	}

	public void finishedLap(){
		Debug.Log("Lap finished!");
        //lapManager.Lap();

	}
}
