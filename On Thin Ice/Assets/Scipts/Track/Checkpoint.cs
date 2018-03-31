using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public int checkpointNumber;
	public int totalNumberOfCheckpoints;
    public GameObject nextCheckpoint;

	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.tag == "Player"){
			collider.gameObject.GetComponent<PlayerController>().passCheckpoint(this);
		}
	}
}
