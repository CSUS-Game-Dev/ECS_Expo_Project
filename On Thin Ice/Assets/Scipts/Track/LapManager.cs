using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapManager : MonoBehaviour {

	public int numberOfCheckpoints = 2;
	public List<Checkpoint> checkpoints = new List<Checkpoint>();
    public Text text;
    private int lapCount, place;

    private int totalLaps = 3;
    private int currentLapCount = 0;

    private bool pass2, pass3, raceFinished;
    public GameObject playerManager, EndInfoPrefab;
    public RectTransform UserInterface;
    public TimeScript time;
   private ArrayList playerInfo = new ArrayList();

    // Use this for initialization
    void Start () {
        lapCount = 1; place = 1;
        pass2 = false; pass3 = false; raceFinished = false;
		for(int i = 0; i < checkpoints.Count; i++){
			checkpoints[i].totalNumberOfCheckpoints = numberOfCheckpoints;
		}
    }
/* 
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
*/

    public void Lap(int num, PlayerController pc){
        if(num > currentLapCount){
            currentLapCount = num;
            if(num < 3){
                text.text = "Lap " + (num + 1) + " / 3";  
            }   
        }
        if(num == totalLaps){
            PlayerFinished(pc.gameObject);
        }
    }

    public void PlayerFinished(GameObject obj)
    {
        PlayerController pc = obj.GetComponent<PlayerController>();
        string objInfo = "Player " + pc.playerNumber + " wins!\n Finished in " + time.getTime() + " seconds";

        place++;
        //playerInfo.Add(objInfo);
        Destroy(obj);
        if(place > playerManager.GetComponent<PlayerManager>().playerNumber){
            EndInfoPrefab.active = true;
            EndInfoPrefab.GetComponentInChildren<Text>().text = objInfo;
        }
    }

/* 
    private void Update()
    {
        if(playerManager.transform.childCount == 0)
        {
            if(raceFinished == false)
            {
                raceFinished = true;
                GameObject temp = Instantiate(EndInfoPrefab);
                temp.transform.SetParent(UserInterface, false);
                EndInfo info = temp.GetComponent<EndInfo>();
                for(int i = 0; i < playerInfo.Count; i++)
                {
                    Debug.Log(playerInfo[i].ToString());
                    info.setNextLine(playerInfo[i].ToString());
                }
            }
            
        }
    }
*/
}
