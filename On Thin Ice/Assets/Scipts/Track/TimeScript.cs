using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {
    private float time;
    public Text text;
	// Use this for initialization
	void Start () {
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        text.text = "Time: " + time.ToString("F2");
	}

    public float getTime()
    {
        return time;
    }
}
