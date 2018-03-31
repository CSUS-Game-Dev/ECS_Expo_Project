using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusAction : MonoBehaviour {

    public Text text;

    public void PlusText()
    {
        int temp = int.Parse(text.text);
        if(temp < 4)
        {
            temp++;
            text.text = temp.ToString();
        }
    }
}
