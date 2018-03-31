using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

	public int playerNumber = -1;

	public Rigidbody rigidbody;
	public float speed = 13f;
	public float accelleration = 10f;
	public GameObject Collider;

	public MeshRenderer bottomBall;

	private float accelMagnitude = .01f;

	private float Forward;
	private float Turn;
	private float Brake;

	private Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		bottomBall = transform.FindChild("BottomBall").GetComponent<MeshRenderer>();
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

	public void setPlayer(int playerNumber){

		Material ballMaterial;

		string materialPath = "WhiteMat";

		switch(playerNumber){
			case 1:
				materialPath = "WhiteMat";
				break;
			case 2:
				materialPath = "GreenMat";
				break;
			case 3:
				materialPath = "YellowMat";
				break;
			case 4:
				materialPath = "BlackMat";
				break;
			default:
				break;
		}

		ballMaterial = Resources.Load(materialPath) as Material;

		bottomBall.material = ballMaterial;

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
