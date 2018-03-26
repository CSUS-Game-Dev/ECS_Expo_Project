using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapManager : MonoBehaviour {

	public int numberOfCheckpoints = 2;
	public List<Checkpoint> checkpoints = new List<Checkpoint>();
    public Text text;

    // Use this for initialization
    void Start () {
		for(int i = 0; i < checkpoints.Count; i++){
			checkpoints[i].totalNumberOfCheckpoints = numberOfCheckpoints;
		}
    }

    public void Lap()
    {
        int lap = int.Parse(text.text.Substring(4, 1));
        lap = lap+1+48;
        char[] array = text.text.ToCharArray();
        array[4] = (char) lap;
        string temp = "";
        for(int i = 0; i < array.Length; i++)
        {
            temp += array[i];
        }
        text.text = temp;
    }
}
