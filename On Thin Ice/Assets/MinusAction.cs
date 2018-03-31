using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinusAction : MonoBehaviour {

    public Text text;

    public void MinusText()
    {
        int temp = int.Parse(text.text);
        if (temp > 1)
        {
            temp--;
            text.text = temp.ToString();
        }
    }
}
