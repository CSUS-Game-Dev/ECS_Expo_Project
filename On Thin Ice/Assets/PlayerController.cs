using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody rigidbody;
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
	
	// Update is called once per frame
	void Update () {
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
	}
}
