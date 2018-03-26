using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapManager : MonoBehaviour {

	public int numberOfCheckpoints = 2;
	public List<Checkpoint> checkpoints = new List<Checkpoint>();
    public Text text;
    private int lapCount, place;
    private bool pass2, pass3;
    public GameObject playerManager;
    public TimeScript time;
    private ArrayList playerInfo = new ArrayList();

    // Use this for initialization
    void Start () {
        lapCount = 1; place = 1;
        pass2 = false; pass3 = false;
		for(int i = 0; i < checkpoints.Count; i++){
			checkpoints[i].totalNumberOfCheckpoints = numberOfCheckpoints;
		}
    }

    public void Lap(int l)
    {
        if(l == lapCount)
        {
            if(pass2 == false || pass3 == false)
            {
                int lap = int.Parse(text.text.Substring(4, 1));
                lap = lap + 1 + 48;
                char[] array = text.text.ToCharArray();
                array[4] = (char)lap;
                string temp = "";
                for (int i = 0; i < array.Length; i++)
                {
                    temp += array[i];
                }
                text.text = temp;
                if(pass2 == false)
                {
                    pass2 = true;
                }
                else
                {
                    pass3 = true;
                }
                lapCount++;
            }
        }
    }

    public void PlayerFinished(GameObject obj)
    {
        string objInfo = place + ": " + obj.name + ", " + time.getTime();
        place++;
        playerInfo.Add(objInfo);
        Destroy(obj);
    }

    private void Update()
    {
        if(playerManager.transform.childCount == 0)
        {
            for(int i = 0; i < playerInfo.Count; i++)
            {
                Debug.Log(playerInfo[i].ToString());
            }
        }
    }
}
