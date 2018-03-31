using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndInfo : MonoBehaviour {
    public Text text;

	// Use this for initialization
	void Start () {
		
	}

    public void setNextLine(string info)
    {
        Debug.Log(info);
        text.text += info + "\n";
    }
}
