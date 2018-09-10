using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerStart : MonoBehaviour {

	public bool timerStarted;
	public float countdownValue = 15f;
	public changeScene changer ;
	public gameManager gm ;


	// Use this for initialization
	void Start () {
		gm = gameManager.instance;
		changer = GameObject.Find("sceneManager").GetComponent<changeScene>() ;
		timerStarted = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (timerStarted == true) {
			countdownValue -= Time.deltaTime;
			if (countdownValue <= 0f) {
				timerStarted = false;
				gm.endNo = 1;
				changer.sceneChange(3) ;
			}
		}
	}
}
