using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

	public Rigidbody rigidbody;
	public float speed = 0;

	public SphereCollider sCol;
	public GameObject Collider;

	private float maxSpeed = .22f;
	private float accelMagnitude = .004f;
	private float friction = .001f;

	private float Forward;
	private float Turn;
	private float Brake;

	private Rigidbody rb;

    private int lapCount;

	void Start() {
		rb = GetComponent<Rigidbody> ();
        lapCount = 1;
	}

	
	public int lastCheckpointPassed = 0;

    public LapManager lapManager;

	// Update is called once per frame
	void Update () {

		Forward = Input.GetAxis ("Vertical") * accelMagnitude;
		Turn = Input.GetAxis ("Horizontal") * 3;

		speed = Mathf.Min (maxSpeed, speed + Forward);
		speed = Mathf.Max (0, speed - friction);


		transform.Translate (0, 0, speed);
		transform.Rotate (0, Turn, 0);

	}

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Wall")) {
			speed = 0;
		}
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
        lapManager.Lap(lapCount);
        lapCount++;
        if(lapCount == 4)
        {
            lapManager.PlayerFinished(gameObject);
        }

	}
}
