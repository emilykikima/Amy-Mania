using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {


	public static gameManager instance;
	public float firstToss ;
	public float currentX;
	public float currentY;
	public int hasHammer = 1 ;
	public int endNo = 0 ;
	public int rings = 0 ;
	public int switches = 0 ;
	public int enemies = 9 ;
	public int currentStage = 0 ;

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}

	
	// Update is called once per frame
	void Update () {

	}
}
