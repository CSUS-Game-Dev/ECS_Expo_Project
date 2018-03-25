using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapManager : MonoBehaviour {

	public int numberOfCheckpoints = 2;
	public List<Checkpoint> checkpoints = new List<Checkpoint>();

	// Use this for initialization
	void Start () {
		for(int i = 0; i < checkpoints.Count; i++){
			checkpoints[i].totalNumberOfCheckpoints = numberOfCheckpoints;
		}
	}
}
