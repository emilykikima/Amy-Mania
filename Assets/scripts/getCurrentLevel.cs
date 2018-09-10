using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getCurrentLevel : MonoBehaviour {

	public gameManager gm ;

	public int level ;

	// Use this for initialization
	void Start () {
		gm = gameManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
		gm.currentStage = level;
	}
}
