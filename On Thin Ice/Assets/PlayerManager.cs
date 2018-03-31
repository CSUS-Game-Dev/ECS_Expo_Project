using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

public GameObject playerCharacterPrefab;

public int playerNumber;

void Start(){
	spawnSnowmen(playerNumber);
}

public void spawnSnowmen(int playerNumbers){
	for(int i = 0; i < playerNumbers; i++){
		GameObject temp = Instantiate(playerCharacterPrefab, this.transform.position + new Vector3((float)(2 * i), 0f, 0f), Quaternion.identity);
		temp.GetComponent<PlayerController>().setPlayer(i + 1);
		temp.transform.SetParent(this.transform);
		temp.transform.position = this.transform.position + new Vector3((float)(2 * i), 0f, 0f);
	}

}


}
