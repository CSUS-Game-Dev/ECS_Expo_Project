using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartAction : MonoBehaviour {

    public Text text;

    public void SavePlayer()
    {
        int temp = int.Parse(text.text);
        PlayerPrefs.SetInt("PlayerCount", temp);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

}
