using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

public GameObject playerCharacterPrefab;

public LapManager lapManager;
public int playerNumber;

void Start(){

	playerNumber = PlayerPrefs.GetInt("PlayerCount", 1);
	spawnSnowmen(playerNumber);

}

public void spawnSnowmen(int playerNumbers){
	for(int i = 0; i < playerNumbers; i++){
		GameObject temp = Instantiate(playerCharacterPrefab, this.transform.position + new Vector3((float)(2 * i), 0f, 0f), Quaternion.identity);
		PlayerController playerController = temp.GetComponent<PlayerController>();
		playerController.setPlayer(i + 1);
		playerController.lapManager = lapManager;
		temp.transform.SetParent(this.transform);
		temp.transform.position = this.transform.position + new Vector3((float)(2 * i), 0f, 0f);
	
	}
}

void Update(){
	if(Input.GetKeyDown(KeyCode.Escape)){
		Application.Quit();
	}
}


}
