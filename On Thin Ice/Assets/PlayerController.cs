﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

	public Rigidbody rigidbody;
<<<<<<< HEAD
	public float speed = 13f;
=======
	public SphereCollider sCol;
	public GameObject Collider;

	private float maxSpeed = .3f;
	private float accelMagnitude = .01f;
	private float speed = 0f;

	private float Forward;
	private float Turn;
	private float Brake;

	private Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}
>>>>>>> Player Controls
	
	public int lastCheckpointPassed = 0;

    public LapManager lapManager;

	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
		Vector3 vel = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
		vel = vel.normalized * speed;
		rigidbody.velocity = vel;
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
        lapManager.Lap();
=======
		Forward = Input.GetAxis ("Vertical");
		Turn = Input.GetAxis ("Horizontal");
		Brake = Input.GetAxis ("Jump");


		speed = speed + Forward * accelMagnitude; 

		Quaternion q;
		Vector3 v;
		transform.Translate (0, 0, speed);
		transform.Rotate (0, Turn * 6, 0);

		speed = Mathf.Min (maxSpeed, speed);
		speed = Mathf.Max (0f, speed - .001f);
>>>>>>> Player Controls
	}
}
